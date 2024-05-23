using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{


    public static SelectionManager Instance { get; set; }


    public bool onTarget;

    public GameObject selectedObject;



    public GameObject interaction_Info_UI;
    Text interaction_text;

    public Image centerDotImage;

    public Image handIcon;

    public bool handIsVisible;

    //arvore
    public GameObject selectedTree;
    public GameObject chopHolder;

    //pedra
    public GameObject selectedStone;
    public GameObject pickHolder;

    //lixo
    public GameObject selectedTrash;
    public GameObject hammerHolder;

    private void Start()
    {
        onTarget = false;
        interaction_text = interaction_Info_UI.GetComponent<Text>();
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    void Update()
    {
        //arvore
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selectionTransform = hit.transform;

            //arvore

            InteractableObject interactable = selectionTransform.GetComponent<InteractableObject>();

            ChoppableTree choppableTree = selectionTransform.GetComponent<ChoppableTree>();

            //pedra
            InteractableObject interactableStone = selectionTransform.GetComponent<InteractableObject>();

            BreakableStone breakableStone = selectionTransform.GetComponent<BreakableStone>();

            //lixo
            InteractableObject interactableTrash = selectionTransform.GetComponent<InteractableObject>();

            BreakableLixo breakableLixo = selectionTransform.GetComponent<BreakableLixo>();


            //arvore
            if (choppableTree && choppableTree.playerInRange)
            {
                choppableTree.canBeChopped = true;
                selectedTree = choppableTree.gameObject;
                chopHolder.gameObject.SetActive(true);
            }
            else
            {
                if (selectedTree != null)
                {
                    selectedTree.gameObject.GetComponent<ChoppableTree>().canBeChopped = false;
                    selectedTree = null;
                    chopHolder.gameObject.SetActive(false);
                }
            }

            //pedra

            if (breakableStone && breakableStone.playerInRange)
            {
                Debug.Log("range");
                breakableStone.canBeBroken = true;
                selectedStone = breakableStone.gameObject;
                pickHolder.gameObject.SetActive(true);
            }
            else
            {
                if (selectedStone != null)
                {
                    Debug.Log("selected");
                    selectedStone.gameObject.GetComponent<BreakableStone>().canBeBroken = false;
                    selectedStone = null;
                    pickHolder.gameObject.SetActive(false);
                }
            }

            //lixo

            if (breakableLixo && breakableLixo.playerInRange)
            {
                Debug.Log("range");
                breakableLixo.canBeBroken = true;
                selectedTrash = breakableLixo.gameObject;
                hammerHolder.gameObject.SetActive(true);
            }
            else
            {
                if (selectedTrash != null)
                {
                    Debug.Log("selected");
                    selectedTrash.gameObject.GetComponent<BreakableLixo>().canBeBroken = false;
                    selectedTrash = null;
                    hammerHolder.gameObject.SetActive(false);
                }
            }

            //arvore

            if (interactable && interactable.playerInRange)
            {

                onTarget = true;
                selectedObject = interactable.gameObject;
                interaction_text.text = interactable.GetItemName();
                interaction_Info_UI.SetActive(true);

                if (interactable.CompareTag("pickable"))
                {
                    centerDotImage.gameObject.SetActive(false);
                    handIcon.gameObject.SetActive(true);
                    handIsVisible = true;

                }
                else
                {
                    handIcon.gameObject.SetActive(false);
                    centerDotImage.gameObject.SetActive(true);

                    handIsVisible = false;

                }

            }
            else
            {

                onTarget = false;
                interaction_Info_UI.SetActive(false);
                handIcon.gameObject.SetActive(false);
                centerDotImage.gameObject.SetActive(true);

                handIsVisible = false;
            }
            if (interactableStone && interactableStone.playerInRange)
            {

                onTarget = true;
                selectedObject = interactableStone.gameObject;
                interaction_text.text = interactableStone.GetItemName();
                interaction_Info_UI.SetActive(true);

                if (interactableStone.CompareTag("pickable"))
                {
                    centerDotImage.gameObject.SetActive(false);
                    handIcon.gameObject.SetActive(true);
                    handIsVisible = true;

                }
                else
                {
                    handIcon.gameObject.SetActive(false);
                    centerDotImage.gameObject.SetActive(true);

                    handIsVisible = false;

                }

            }
            else
            {

                onTarget = false;
                interaction_Info_UI.SetActive(false);
                handIcon.gameObject.SetActive(false);
                centerDotImage.gameObject.SetActive(true);

                handIsVisible = false;
            }
        }
        else
        {

            onTarget = false;
            interaction_Info_UI.SetActive(false);
            handIcon.gameObject.SetActive(false);
            centerDotImage.gameObject.SetActive(true);

            handIsVisible = false;
        }

    }
        
        
   
    public void DisableSelection()
    {
        handIcon.enabled = false;
        centerDotImage.enabled = false;
        interaction_Info_UI.SetActive(false);

        selectedObject = null;


    }

    public void EnableSelection()
    {
        handIcon.enabled = true;
        centerDotImage.enabled = true;
        interaction_Info_UI.SetActive(true);
    }

}
