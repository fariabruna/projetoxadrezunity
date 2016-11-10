using UnityEngine;
using tabuleiro;
using xadrez;
using UnityEngine.UI;

class GameController : MonoBehaviour {

    public GameObject TorreBranca = null;
    public GameObject reiBranco = null;

    public GameObject TorrePreta = null;
    public GameObject reiPreto = null;

    public Text txtMsg = null;
    public Text txtXeque = null;

    public GameObject pecaEscolhida { get; private set; }

    public Estado estado { get; private set; }

    PartidaDeXadrez partida;
    PosicaoXadrez origem, destino;
    Color corOriginal;

	void Start () {
        estado = Estado.AguardandoJogada;
        pecaEscolhida = null;
        corOriginal = txtMsg.color;

        partida = new PartidaDeXadrez();
        txtXeque.text = "";
        informarAguardando();

        Util.instanciarTorre('a', 1, Cor.Branca, partida, TorreBranca);
        Util.instanciarTorre('h', 1, Cor.Branca, partida, TorreBranca);
        Util.instanciarRei('e', 1, Cor.Branca, partida, reiBranco);

        Util.instanciarTorre('h', 8, Cor.Preta, partida, TorrePreta);
        Util.instanciarTorre('a', 8, Cor.Preta, partida, TorrePreta);
        Util.instanciarRei('e', 8, Cor.Preta, partida, reiPreto);

    }

    public void processarMouseDown(GameObject peca, GameObject casa){
        if (estado == Estado.AguardandoJogada){
            if(casa != null){
                try{
                    char coluna = casa.name[0];
                    int linha = casa.name[1] - '0';
                    origem = new PosicaoXadrez(coluna, linha);
                    partida.validarPosicaoDeOrigem(origem.toPosicao());
                    pecaEscolhida = peca;
                    estado = Estado.Arrastando;
                    txtMsg.text = "Solte a peça na casa de destino";
                }
                catch(TabuleiroException e){
                    peca.transform.position = Util.posicaoNaCena(origem.coluna, origem.linha);
                    estado = Estado.AguardandoJogada;
                    informarAviso(e.Message);
                }
            }
        }
    }

    public void processarMouseUp(GameObject peca, GameObject casa){
        if (estado == Estado.Arrastando){
            if (casa != null){
                if (pecaEscolhida != null && pecaEscolhida == peca){
                    try{
                        char coluna = casa.name[0];
                        int linha = casa.name[1] - '0';
                        destino = new PosicaoXadrez(coluna, linha);

                        partida.validarPosicaoDeDestino(origem.toPosicao(), destino.toPosicao());
                        partida.realizaJogada(origem.toPosicao(), destino.toPosicao());

                        peca.transform.position = Util.posicaoNaCena(coluna, linha);

                        pecaEscolhida = null;
                        estado = Estado.AguardandoJogada;
                        informarAguardando();
                    }
                    catch (TabuleiroException e){
                        peca.transform.position = Util.posicaoNaCena(origem.coluna, origem.linha);
                        estado = Estado.AguardandoJogada;
                        informarAviso(e.Message);
                    }
                }
            }
        }
    }

    void informarAviso (string msg){
        txtMsg.color = Color.red;
        txtMsg.text = msg;
        Invoke("InformarAguardando", 1f);
    }

    void informarAguardando(){
        txtMsg.color = corOriginal;
        txtMsg.text = "Aguardando jogada: " + partida.jogadorAtual;
    }
}
