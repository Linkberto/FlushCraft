using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Animator))]

public class EquipableItem : MonoBehaviour
{


    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) &&
            InventorySystem.Instance.isOpen == false
            && CraftingSystem.Instance.isOpen == false &&
            SelectionManager.Instance.handIsVisible == false ) // botao esquerdo
        {


            SoundManager.Instance.PlaySound(SoundManager.Instance.swingFerr);


            animator.SetTrigger("hit");
        }
    }

    public void GetHit()
    {
        GameObject selectedTree = SelectionManager.Instance.selectedTree;

        if (selectedTree != null)
        {
            selectedTree.GetComponent<ChoppableTree>().GetHit();
        }
       
    }

  


}
