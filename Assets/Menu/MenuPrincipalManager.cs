using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    FadeInOut fade;
    [SerializeField] private string nomeDoLevel;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;


    void Start()
    {
        fade = FindObjectOfType<FadeInOut>();
    }

    public IEnumerator _MenuPrincipalManager()
    {
        fade.FadeIn();
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("tutorial1");
    }

    public void Jogar()
    {
        StartCoroutine(_MenuPrincipalManager());
    }


    public void AbrirOpcoes()
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }


    public void FecharOpcoes()
    {
        painelOpcoes.SetActive(false );
        painelMenuInicial.SetActive(true );
    }


    public void SairJogo()
    {
        Debug.Log("Sair do jogo");
        Application.Quit();

    }
}
