using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    FadeInOut fade;
    [SerializeField] private string nomeDaFase;
    [SerializeField] private GameObject painelMenu;

    void Start()
    {
        fade = FindObjectOfType<FadeInOut>();
    }

    public IEnumerator _NextLevel()
    {
        fade.FadeIn();
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Jogo1");
    }


    public void Jogar()
    {
        StartCoroutine(_NextLevel());

    }
}
