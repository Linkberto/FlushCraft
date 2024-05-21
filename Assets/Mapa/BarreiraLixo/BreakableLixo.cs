using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableLixo : MonoBehaviour
{

    public bool playerInRange;
    public bool canBeBroken;

    public float trashMaxHealth;
    public float trashHealth;

    public GameObject aguaUm;
    public GameObject aguaDois;

    public Animator animator;

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



    public void GetHitHammer()
    {
        animator.SetTrigger("shake");

        trashHealth -= 5;

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

        Destroy(transform.parent.transform.parent.gameObject);
        canBeBroken = false;
        SelectionManager.Instance.selectedStone = null;
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
