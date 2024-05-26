using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BreakableLixo : MonoBehaviour
{

    public bool playerInRange;
    public bool canBeBroken;

    public Vector3 teleportPosition;

    public float trashMaxHealth;
    public float trashHealth;

    public Animator animator;

    public GameObject aguaUm;
    public GameObject aguaDois;

    public GameObject barreira;

    public GameObject barreirainv1;
    public GameObject barreirainv2;

    public GameObject waypoint2;

    private void Start()
    {
        trashHealth = trashMaxHealth;
        animator = transform.parent.transform.parent.GetComponent<Animator>();

        
            aguaUm.SetActive(false);

            aguaDois.SetActive(true);
        
        
            barreira.SetActive(true);


        barreirainv1.SetActive(false);
        barreirainv2.SetActive(false);
        
       

            waypoint2.SetActive(false);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }



    public void GetHitH()
    {
        //animator.SetTrigger("shake");

        trashHealth -= 2;
        Debug.Log("deu dano");

        if (trashHealth <= 0)
        {
            TrashIsDead();
        }

    }



    void TrashIsDead()
    {
        Vector3 trashPosition = transform.position;

        
            aguaUm.SetActive(true);



             Destroy(aguaDois);
        

        
            barreira.SetActive(false);

             barreirainv1.SetActive(true);
        barreirainv2.SetActive(true);
           
            
            waypoint2.SetActive(true);

        Destroy(transform.parent.transform.parent.gameObject);
        canBeBroken = false;
        SelectionManager.Instance.selectedTrash = null;
        SelectionManager.Instance.hammerHolder.gameObject.SetActive(false);

        TeleportPlayer();


    }

    void TeleportPlayer()
    {
        // Verifica se o player existe antes de definir a posição
        GameObject player = GameObject.FindWithTag("Player"); // Supondo que o player tenha a tag "Player"
        if (player != null)
        {
            player.transform.position = teleportPosition;
        }
    }

    private void Update()
    {
        if (canBeBroken)
        {
            GlobalState.Instance.resourceHealth = trashHealth;
            GlobalState.Instance.resourceMaxHealth = trashMaxHealth;
        }
    }

}