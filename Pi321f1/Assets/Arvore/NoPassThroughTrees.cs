using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoPassThroughTrees : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private bool isColliding = false;

    void Start()
    {
        // Obt�m o Rigidbody do jogador
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Verifica se o jogador est� colidindo com um objeto
        if (isColliding)
        {
            // Desativa temporariamente a gravidade do jogador
            playerRigidbody.useGravity = false;
        }
        else
        {
            // Ativa a gravidade do jogador novamente
            playerRigidbody.useGravity = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que colidiu � o jogador
        if (other.CompareTag("Player"))
        {
            isColliding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica se o objeto que colidiu � o jogador
        if (other.CompareTag("Player"))
        {
            isColliding = false;
        }
    }
}
