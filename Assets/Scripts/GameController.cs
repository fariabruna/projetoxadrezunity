using UnityEngine;
using tabuleiro;
using xadrez;

class GameController : MonoBehaviour {

    public GameObject TorreBranca = null;
    public GameObject reiBranco = null;

    public GameObject TorrePreta = null;
    public GameObject reiPreto = null;

    PartidaDeXadrez partida;

	void Start () {
        partida = new PartidaDeXadrez();
        Util.instanciarTorre('a', 1, Cor.Branca, partida, TorreBranca);
        Util.instanciarTorre('h', 1, Cor.Branca, partida, TorreBranca);
        Util.instanciarRei('e', 1, Cor.Branca, partida, reiBranco);

        Util.instanciarTorre('h', 8, Cor.Preta, partida, TorrePreta);
        Util.instanciarTorre('a', 8, Cor.Preta, partida, TorrePreta);
        Util.instanciarRei('e', 8, Cor.Preta, partida, reiPreto);

    }
}
