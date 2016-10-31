using UnityEngine;
using tabuleiro;
using xadrez;

class GameController : MonoBehaviour {

    public GameObject TorreBranca = null;
    PartidaDeXadrez partida;

	void Start () {
        partida = new PartidaDeXadrez();
        Util.instanciarTorre('a', 1, Cor.Branca, partida, TorreBranca);
        Util.instanciarTorre('h', 1, Cor.Branca, partida, TorreBranca);
    }
}
