using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{



    public bool playerInRange;

    public string ItemName;

    public string GetItemName()
    {
        return ItemName;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && playerInRange && SelectionManager.Instance.onTarget && SelectionManager.Instance.selectedObject == gameObject)
        {

            //se o inv nao estiver cheio
            if (!InventorySystem.Instance.CheckIfFull())
            {
                InventorySystem.Instance.AddToInventory(ItemName);

                Destroy(gameObject);
            }
            //se tiver chei
            else
            {

                Debug.Log("Ta chei o inventorio!");
            }

        }


    }









    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            playerInRange= true;

        }



    }

    private void OnTriggerExit(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {


            playerInRange = false;


        }



    }
}