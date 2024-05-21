using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipablePickaxe : MonoBehaviour
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
            SelectionManager.Instance.handIsVisible == false) // botao esquerdo
        {




            animator.SetTrigger("hitpick");
        }
    }

    public void GetHitPick()
    {
       
        GameObject selectedStone = SelectionManager.Instance.selectedStone;

        if (selectedStone != null)
        {
            selectedStone.GetComponent<BreakableStone>().GetHitPick();
        }
    }




}
