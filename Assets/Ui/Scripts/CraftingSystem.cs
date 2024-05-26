using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSystem : MonoBehaviour
{
    public GameObject craftingScreenUI;
    public GameObject toolsScreenUI;
    public GameObject toolsScreenUI2;


    public List<string> inventoryItemList = new List<string>();


    //categorias de botoes

    Button toolsBTN;
    Button toolsBTN2;

    //botoes de craftar
    Button craftAxeBTN;
    Button craftPickaxeBTN;
    Button craftHammerBTN;
    Button craftGradeBTN;
    Button craftLinhaBTN;
    Button craftPeneiraBTN;


    //requerimentos texto
    Text AxeReq1, AxeReq2;
    Text PickaxeReq1, PickaxeReq2;
    Text HammerReq1, HammerReq2;
    Text LinhaReq1, LinhaReq2;
    Text GradeReq1, GradeReq2;
    Text PeneiraReq1, PeneiraReq2;

    public bool isOpen;

    //todos os blueprint
    public Blueprint AxeBLP = new Blueprint("Axe", 2, "Stick", 3, "Stone", 3);

    public Blueprint PickaxeBLP = new Blueprint("Pickaxe", 2, "Petrified Wood Log", 2, "Stone", 3);

    public Blueprint HammerBLP = new Blueprint("Hammer", 2, "Petrified Wood Log", 4, "Strong Stone", 6);

    public Blueprint LinhaBLP = new Blueprint("Thread Spool", 2, "Cotton", 6, "Stick", 1);

    public Blueprint GradeBLP = new Blueprint("Bamboo Grid", 2, "Bamboos", 5, "Thread Spool", 1);

    public Blueprint PeneiraBLP = new Blueprint("Bamboo Sieve", 2, "Bamboo Grid", 1, "Thread Spool", 1);




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

        toolsBTN = craftingScreenUI.transform.Find("BasicToolsButton").GetComponent<Button>();



        toolsBTN.onClick.AddListener(delegate { OpenToolsCategory(); });

        //machado
        AxeReq1 = toolsScreenUI.transform.Find("Axe").transform.Find("req1").GetComponent<Text>();
        AxeReq2 = toolsScreenUI.transform.Find("Axe").transform.Find("req2").GetComponent<Text>();

        craftAxeBTN = toolsScreenUI.transform.Find("Axe").transform.Find("Button").GetComponent<Button>();
        craftAxeBTN.onClick.AddListener(delegate { CraftAnyItem(AxeBLP); });

        //picareta
        PickaxeReq1 = toolsScreenUI.transform.Find("Pickaxe").transform.Find("req1").GetComponent<Text>();
        PickaxeReq2 = toolsScreenUI.transform.Find("Pickaxe").transform.Find("req2").GetComponent<Text>();

        craftPickaxeBTN = toolsScreenUI.transform.Find("Pickaxe").transform.Find("Button").GetComponent<Button>();
        craftPickaxeBTN.onClick.AddListener(delegate { CraftAnyItem(PickaxeBLP); });

        //hammer
        HammerReq1 = toolsScreenUI.transform.Find("Hammer").transform.Find("req1").GetComponent<Text>();
        HammerReq2 = toolsScreenUI.transform.Find("Hammer").transform.Find("req2").GetComponent<Text>();

        craftHammerBTN = toolsScreenUI.transform.Find("Hammer").transform.Find("Button").GetComponent<Button>();
        craftHammerBTN.onClick.AddListener(delegate { CraftAnyItem(HammerBLP); });




       //mmedium tools

        toolsBTN2 = craftingScreenUI.transform.Find("MediumToolsButton").GetComponent<Button>();
        toolsBTN2.onClick.AddListener(delegate { OpenToolsCategory2(); });


        toolsBTN2.onClick.AddListener(delegate { OpenToolsCategory2(); });

        //algodao

        LinhaReq1 = toolsScreenUI2.transform.Find("ThreadSpool").transform.Find("req1").GetComponent<Text>();
        LinhaReq2 = toolsScreenUI2.transform.Find("ThreadSpool").transform.Find("req2").GetComponent<Text>();

        craftLinhaBTN = toolsScreenUI2.transform.Find("ThreadSpool").transform.Find("Button").GetComponent<Button>();
        craftLinhaBTN.onClick.AddListener(delegate { CraftAnyItem(LinhaBLP); });

        //grade

        GradeReq1 = toolsScreenUI2.transform.Find("BambooGrid").transform.Find("req1").GetComponent<Text>();
        GradeReq2 = toolsScreenUI2.transform.Find("BambooGrid").transform.Find("req2").GetComponent<Text>();

        craftGradeBTN = toolsScreenUI2.transform.Find("BambooGrid").transform.Find("Button").GetComponent<Button>();
        craftGradeBTN.onClick.AddListener(delegate { CraftAnyItem(GradeBLP); });

        //peneira

        PeneiraReq1 = toolsScreenUI2.transform.Find("BambooSieve").transform.Find("req1").GetComponent<Text>();
        PeneiraReq2 = toolsScreenUI2.transform.Find("BambooSieve").transform.Find("req2").GetComponent<Text>();

        craftPeneiraBTN = toolsScreenUI2.transform.Find("BambooSieve").transform.Find("Button").GetComponent<Button>();
        craftPeneiraBTN.onClick.AddListener(delegate { CraftAnyItem(PeneiraBLP); });

    }

    //basic tools
    void OpenToolsCategory()
    {
        craftingScreenUI.SetActive(false);
        toolsScreenUI.SetActive(true);

    }

    //mediumtools
    void OpenToolsCategory2()
    {
        craftingScreenUI.SetActive(false);
        toolsScreenUI2.SetActive(true);

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

            Debug.Log("c ta pressionado");
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
            toolsScreenUI2.SetActive(false);

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
        int pwl_count = 0;
        int strongstone_count = 0;
        int cotton_count = 0;
        int bamboo_count = 0;
        int thread_count = 0;
        int grid_count = 0;

        //st = Thread Spool
        //PWL = petrifield wooden log

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

                case "Petrified Wood Log":
                    pwl_count += 1;
                    break;

                case "Strong Stone":
                    strongstone_count += 1;
                    break;

                case "Cotton":
                    cotton_count += 1;
                    break;

                case "Bamboo":
                    bamboo_count += 1;
                    break;

                case "Thread Spool":
                    thread_count += 1;
                    break;

                case "Bamboo Grid":
                    grid_count += 1;
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

            //-------Pickaxe--------//
            PickaxeReq1.text = "3 Stone [" + stone_count + "]";
            PickaxeReq2.text = "2 Petrified Wood [" + pwl_count + "]";

            if (stone_count >= 3 && pwl_count >= 2)

            {
                craftPickaxeBTN.gameObject.SetActive(true);
            }

            else
            {

                craftPickaxeBTN.gameObject.SetActive(false);

            }


            //-------Hammer--------//
            HammerReq1.text = "6 Strong Stone [" + strongstone_count + "]";
            HammerReq2.text = "4 Petrified Wood [" + pwl_count + "]";

            if (strongstone_count >= 6 && pwl_count >= 4)

            {
                craftHammerBTN.gameObject.SetActive(true);
            }

            else
            {

                craftHammerBTN.gameObject.SetActive(false);

            }


            //-------Cotton--------//
            LinhaReq1.text = "6 Cotton [" + cotton_count + "]";
            LinhaReq2.text = "1 Stick [" + stick_count + "]";

            if (cotton_count >= 6 && stick_count >= 1)

            {
                craftLinhaBTN.gameObject.SetActive(true);
            }

            else
            {

                craftLinhaBTN.gameObject.SetActive(false);

            }

            //-------Grade--------//

            GradeReq1.text = "5 Bamboos [" + bamboo_count + "]";
            GradeReq2.text = "1 Thread Spool [" + thread_count + "]";

            if (bamboo_count >= 5 && thread_count >= 1)

            {
                craftGradeBTN.gameObject.SetActive(true);
            }

            else
            {

                craftGradeBTN.gameObject.SetActive(false);

            }

            //-------peneira--------//

            PeneiraReq1.text = "1 Bamboo Sieve [" + grid_count + "]";
            PeneiraReq2.text = "1 Thread Spool [" + thread_count + "]";

            if (grid_count >= 1 && thread_count >= 1)

            {
                craftPeneiraBTN.gameObject.SetActive(true);
            }

            else
            {

                craftPeneiraBTN.gameObject.SetActive(false);

            }


        }
    }
}
