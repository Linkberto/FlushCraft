using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BreakableLixo : MonoBehaviour
{

    public bool playerInRange;
    public bool canBeBroken;

    public float trashMaxHealth;
    public float trashHealth;

    public Animator animator;

    public GameObject aguaUm;
    public GameObject aguaDois;

    public GameObject barreira;

    public GameObject barreirainv1;
    public GameObject barreirainv2;

    private void Start()
    {
        trashHealth = trashMaxHealth;
        animator = transform.parent.transform.parent.GetComponent<Animator>();

        if (aguaUm != null)
        {
            aguaUm.SetActive(false);
        }
        if (aguaDois != null)
        {
            aguaDois.SetActive(true);
        }
        if (barreira != null)
        {
            barreira.SetActive(true);
        }
        if (barreirainv1 != null)
        {
            barreira.SetActive(false);
        }
        if (barreirainv2 != null)
        {
            barreira.SetActive(false);
        }
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

        if (aguaUm != null)
        {
            aguaUm.SetActive(true);
        }

        if (aguaDois != null)
        {
            aguaDois.SetActive(false);
        }

        if (barreira != null)
        {
            barreira.SetActive(false);
        }

        if (barreirainv1 != null)
        {
            barreira.SetActive(true);
        }

        if (barreirainv2 != null)
        {
            barreira.SetActive(true);
        }

        Destroy(transform.parent.transform.parent.gameObject);
        canBeBroken = false;
        SelectionManager.Instance.selectedTrash = null;
        SelectionManager.Instance.hammerHolder.gameObject.SetActive(false);

       
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