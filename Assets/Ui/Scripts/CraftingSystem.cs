using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSystem : MonoBehaviour
{
    public GameObject craftingScreenUI;
    public GameObject toolsScreenUI;
    public GameObject toolsScreenUI2;
    public GameObject toolsScreenUI3;

    public List<string> inventoryItemList = new List<string>();


    //categorias de botoes

    Button toolsBTN;
    Button toolsBTN2;
    Button toolsBTN3;

    //botoes de craftar
    Button craftAxeBTN;
    Button craftPickaxeBTN;
    Button craftHammerBTN;

    Button craftGradeBTN;
    Button craftLinhaBTN;
    Button craftPeneiraBTN;

    Button craftCarvAlBTN;
    Button craftGraFinBTN;
    Button craftFilterBTN;



    //requerimentos texto
    Text AxeReq1, AxeReq2;
    Text PickaxeReq1, PickaxeReq2;
    Text HammerReq1, HammerReq2;

    Text LinhaReq1, LinhaReq2;
    Text GradeReq1, GradeReq2;
    Text PeneiraReq1, PeneiraReq2;

    Text CarvAlReq1, CarvAlReq2;
    Text GraFinReq1, GraFinReq2;
    Text FilterReq1, FilterReq2;

    public bool isOpen;

    //todos os blueprint
    public Blueprint AxeBLP = new Blueprint("Axe", 2, "Stick", 3, "Stone", 3);

    public Blueprint PickaxeBLP = new Blueprint("Pickaxe", 2, "Petrified Wood Log", 2, "Stone", 3);

    public Blueprint HammerBLP = new Blueprint("Hammer", 2, "Petrified Wood Log", 4, "Strong Stone", 6);



    public Blueprint LinhaBLP = new Blueprint("Thread Spool", 2, "Cotton", 2, "Stick", 1);

    public Blueprint GradeBLP = new Blueprint("Bamboo Grid", 2, "Bamboo", 3, "Thread Spool", 1);

    public Blueprint PeneiraBLP = new Blueprint("Bamboo Sieve", 2, "Bamboo Grid", 1, "Thread Spool", 1);


    public Blueprint CarvAlBLP = new Blueprint("Charcoal and Cotton", 2, "Petrified Wood Log", 8, "Cotton", 8);

    public Blueprint GraFinBLP = new Blueprint("Gravel and Fine Sand", 2, "Gravel", 6, "Sand", 5);

    public Blueprint FilterBLP = new Blueprint("Cleaning Filter", 2, "Charcoal and Cotton", 1, "Gravel and Fine Sand", 1);



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




       //medium tools

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


        //advanced tools
        toolsBTN3 = craftingScreenUI.transform.Find("AdvancedToolsButton").GetComponent<Button>();
        toolsBTN3.onClick.AddListener(delegate { OpenToolsCategory3(); });

        //Charcoal

        CarvAlReq1 = toolsScreenUI3.transform.Find("CharcoalandCotton").transform.Find("req1").GetComponent<Text>();
        CarvAlReq2 = toolsScreenUI3.transform.Find("CharcoalandCotton").transform.Find("req2").GetComponent<Text>();

        craftCarvAlBTN = toolsScreenUI3.transform.Find("CharcoalandCotton").transform.Find("Button").GetComponent<Button>();
        craftCarvAlBTN.onClick.AddListener(delegate { CraftAnyItem(CarvAlBLP); });

        //gravel

        GraFinReq1 = toolsScreenUI3.transform.Find("GravelandFineSand").transform.Find("req1").GetComponent<Text>();
        GraFinReq2 = toolsScreenUI3.transform.Find("GravelandFineSand").transform.Find("req2").GetComponent<Text>();

        craftGraFinBTN = toolsScreenUI3.transform.Find("GravelandFineSand").transform.Find("Button").GetComponent<Button>();
        craftGraFinBTN.onClick.AddListener(delegate { CraftAnyItem(GraFinBLP); });

        //filter

        FilterReq1 = toolsScreenUI3.transform.Find("CleaningFilter").transform.Find("req1").GetComponent<Text>();
        FilterReq2 = toolsScreenUI3.transform.Find("CleaningFilter").transform.Find("req2").GetComponent<Text>();

        craftFilterBTN = toolsScreenUI3.transform.Find("CleaningFilter").transform.Find("Button").GetComponent<Button>();
        craftFilterBTN.onClick.AddListener(delegate { CraftAnyItem(FilterBLP); });


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

    //advanced tools
    void OpenToolsCategory3()
    {
        craftingScreenUI.SetActive(false);
        toolsScreenUI3.SetActive(true);

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
            SoundManager.Instance.PlaySound(SoundManager.Instance.inventSound);

        }
        else if (Input.GetKeyDown(KeyCode.C) && isOpen)
        {
            craftingScreenUI.SetActive(false);
            toolsScreenUI.SetActive(false);
            toolsScreenUI2.SetActive(false);
            toolsScreenUI3.SetActive(false);

            if (!InventorySystem.Instance.isOpen)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                SelectionManager.Instance.EnableSelection();
                SelectionManager.Instance.GetComponent<SelectionManager>().enabled = true;
                SoundManager.Instance.PlaySound(SoundManager.Instance.inventSound);
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
        int gravel_count = 0;
        int sand_count = 0;
        int chaCo_count = 0;
        int graFi_count = 0;

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

                case "Gravel":
                    gravel_count += 1;
                    break;

                case "Sand":
                    sand_count += 1;
                    break;

                case "Charcoal and Cotton":
                    chaCo_count += 1;
                    break;

                case "Gravel and Fine Sand":
                    graFi_count += 1;
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
            LinhaReq1.text = "2 Cotton [" + cotton_count + "]";
            LinhaReq2.text = "1 Stick [" + stick_count + "]";

            if (cotton_count >= 2 && stick_count >= 1)

            {
                craftLinhaBTN.gameObject.SetActive(true);
            }

            else
            {

                craftLinhaBTN.gameObject.SetActive(false);

            }

            //-------Grade--------//

            GradeReq1.text = "3 Bamboos [" + bamboo_count + "]";
            GradeReq2.text = "1 Thread Spool [" + thread_count + "]";

            if (bamboo_count >= 3 && thread_count >= 1)

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

            //-------Charcoal and Cotton--------//

            CarvAlReq1.text = "8 Petrified Wood [" + pwl_count + "]";
            CarvAlReq2.text = "8 Cottons [" + cotton_count + "]";

            if (pwl_count >= 8 && cotton_count >= 8)

            {
                craftCarvAlBTN.gameObject.SetActive(true);
            }

            else
            {

                craftCarvAlBTN.gameObject.SetActive(false);

            }

            //-------Gravel and Fine Sand--------//

            GraFinReq1.text = "6 Gravels [" + gravel_count + "]";
            GraFinReq2.text = "5 Sands [" + sand_count + "]";

            if (gravel_count >= 6 && sand_count >= 5)

            {
                craftGraFinBTN.gameObject.SetActive(true);
            }

            else
            {

                craftGraFinBTN.gameObject.SetActive(false);

            }
            //-------Filter--------//

            FilterReq1.text = "1 Charcoal and Cotton [" + chaCo_count + "]";
            FilterReq2.text = "1 Gravel and Fine Sand [" + graFi_count + "]";

            if (chaCo_count >= 1 && graFi_count >= 1)

            {
                craftFilterBTN.gameObject.SetActive(true);
            }

            else
            {

                craftFilterBTN.gameObject.SetActive(false);

            }

        }
    }
}
