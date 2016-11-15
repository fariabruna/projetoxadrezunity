using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
public class PrologoUIController : MonoBehaviour{

    int paginaAtual;
    int N;
    List<GameObject> paginas;

    void Start(){
        paginaAtual = 0;
        N = 1;
        paginas = new List<GameObject>();

        GameObject obj = GameObject.Find("pag0");
        paginas.Add(obj);
        obj = GameObject.Find("pag" + N);
        while (obj != null){
            paginas.Add(obj);
            obj.SetActive(false);
            N++;
            obj = GameObject.Find("pag" + N);
        }
    }

    int proxima(int i){
        return (i == N - 1) ? 0 : i + 1;
    }
    int anterior(int i){
        return (i == 0) ? N - 1 : i - 1; 
    }
    public void avancarPagina(){
        paginas[paginaAtual].SetActive(false);
        paginaAtual = proxima(paginaAtual);
        paginas[paginaAtual].SetActive(true);
    }

    public void voltarPagina(){
        paginas[paginaAtual].SetActive(false);
        paginaAtual = anterior(paginaAtual);
        paginas[paginaAtual].SetActive(true);
    }

    public void Sair(){
        SceneManager.LoadScene("inicio");
    }
}
