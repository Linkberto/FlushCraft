using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSystem : MonoBehaviour
{
    public GameObject craftingScreenUI;
    public GameObject toolsScreenUI;


    public List<string> inventoryItemList = new List<string>();


    //categorias de botoes

    Button toolsBTN;

    //botoes de craftar
    Button craftAxeBTN;


    //requerimentos texto
    Text AxeReq1, AxeReq2;

    public bool isOpen;

    //todos os blueprint
    public Blueprint AxeBLP = new Blueprint("Axe", 2, "Stick", 3, "Stone", 3);




    public static CraftingSystem Instance { get; set; }


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
    void Start()
    {

        isOpen = false;

        toolsBTN = craftingScreenUI.transform.Find("ToolsButton").GetComponent<Button>();

        toolsBTN.onClick.AddListener(delegate { OpenToolsCategory(); });

        //machado
        AxeReq1 = toolsScreenUI.transform.Find("Axe").transform.Find("req1").GetComponent<Text>();
        AxeReq2 = toolsScreenUI.transform.Find("Axe").transform.Find("req2").GetComponent<Text>();

        craftAxeBTN = toolsScreenUI.transform.Find("Axe").transform.Find("Button").GetComponent<Button>();
        craftAxeBTN.onClick.AddListener(delegate { CraftAnyItem(AxeBLP); });


    }

    void OpenToolsCategory()
    {
        craftingScreenUI.SetActive(false);
        toolsScreenUI.SetActive(true);

    }

    void CraftAnyItem(Blueprint blueprintToCraft)
    {
        //adicionar item no inventorio
        InventorySystem.Instance.AddToInventory(blueprintToCraft.itemName);

        if(blueprintToCraft.numOfRequirements == 1)
        {
            InventorySystem.Instance.RemoveItem(blueprintToCraft.Req1, blueprintToCraft.Req1amount);

        } 
        else if (blueprintToCraft.numOfRequirements == 2)
        {
            InventorySystem.Instance.RemoveItem(blueprintToCraft.Req1, blueprintToCraft.Req1amount);
            InventorySystem.Instance.RemoveItem(blueprintToCraft.Req2, blueprintToCraft.Req2amount);

        }

        //remover recursos do inventario




        //limpar lista

        StartCoroutine(calculate());

        


    }

    public IEnumerator calculate()
    {
        yield return 0; //sem delay

        InventorySystem.Instance.ReCalculateList();
        RefreshNeededItems(); //add isso
    }

    // Update is called once per frame
    void Update()
    {




        if (Input.GetKeyDown(KeyCode.C) && !isOpen)
        {

            Debug.Log("i ta pressionado");
            craftingScreenUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SelectionManager.Instance.DisableSelection();
            SelectionManager.Instance.GetComponent<SelectionManager>().enabled = false;
            isOpen = true;

        }
        else if (Input.GetKeyDown(KeyCode.C) && isOpen)
        {
            craftingScreenUI.SetActive(false);
            toolsScreenUI.SetActive(false);

            if (!InventorySystem.Instance.isOpen)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                SelectionManager.Instance.EnableSelection();
                SelectionManager.Instance.GetComponent<SelectionManager>().enabled = true;

            }

            isOpen = false;
        }
    }
    public void RefreshNeededItems()
    {

        int stone_count = 0;
        int stick_count = 0;

        inventoryItemList = InventorySystem.Instance.itemList;

        foreach (string itemName in inventoryItemList)
        {


            switch (itemName)
            {
                case "Stone":
                    stone_count += 1;
                    break;
                case "Stick":
                    stick_count += 1;
                    break;

            }


            //-------AXE--------//
            AxeReq1.text = "3 Stone [" + stone_count + "]";
            AxeReq2.text = "3 Stick [" + stick_count + "]";

            if (stone_count >= 3 && stick_count >= 3) 
            
            { 
                craftAxeBTN.gameObject.SetActive(true);
            }

            else
            {

                craftAxeBTN.gameObject.SetActive(false);

            }




        }








    }










}
