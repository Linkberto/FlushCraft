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

            SoundManager.Instance.PlaySound(SoundManager.Instance.swingFerr);


            Debug.Log("animacao");
            animator.SetTrigger("hithit");
        }
    }

    public void GetHitH()
    {
        Debug.Log("eqphammer");
        GameObject selectedTrash = SelectionManager.Instance.selectedTrash;

        if (selectedTrash != null)
        {
            selectedTrash.GetComponent<BreakableLixo>().GetHitH();
        }
    }




}

