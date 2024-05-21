using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipableHammer : MonoBehaviour
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




            animator.SetTrigger("hithammer");
        }
    }

    public void GetHitHammer()
    {

        GameObject selectedTrash = SelectionManager.Instance.selectedStone;

        if (selectedTrash != null)
        {
            selectedTrash.GetComponent<BreakableLixo>().GetHitHammer();
        }
    }




}

