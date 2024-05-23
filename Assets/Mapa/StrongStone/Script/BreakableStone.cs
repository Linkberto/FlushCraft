using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BreakableStone : MonoBehaviour
{

    public bool playerInRange;
    public bool canBeBroken;

    public float stoneMaxHealth;
    public float stoneHealth;

    public Animator animator;

    private void Start()
    {
        stoneHealth = stoneMaxHealth;
        animator = transform.parent.transform.parent.GetComponent<Animator>();
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


  
    public void GetHitPick()
    {
        //animator.SetTrigger("shake");

        stoneHealth -= 2;

        if (stoneHealth <= 0)
        {
            StoneIsDead();
        }

    }



    void StoneIsDead()
    {
        Vector3 stonePosition = transform.position;

        Destroy(transform.parent.transform.parent.gameObject);
        canBeBroken = false;
        SelectionManager.Instance.selectedStone = null;
        SelectionManager.Instance.pickHolder.gameObject.SetActive(false);

        GameObject brokenStone = Instantiate(Resources.Load<GameObject>("BrokenStone"),
          new Vector3(stonePosition.x, stonePosition.y + 1, stonePosition.z), Quaternion.Euler(0, 0, 0));
    }

    private void Update()
    {
        if (canBeBroken)
        {
            GlobalState.Instance.resourceHealth = stoneHealth;
            GlobalState.Instance.resourceMaxHealth = stoneMaxHealth;
        }
    }
    
}