using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSystem : MonoBehaviour
{
    public GameObject craftingScreenUI;
    public GameObject toolsScreenUI;


    public List<string> inventroyItemList = new List<string>();


    //categorias de botoes

    Button toolsBTN;

    //botoes de craftar
    Button craftAxeBTN;


    //requerimentos texto
    Text AxeReq1, AxeReq2;

    public bool isOpen;

    //todos os blueprint





    public static CraftingSystem Instance { get; set; }


    private void Awake()
    {
        if (Instance !=null && Instance != this)
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
        AxeReq2 = toolsScreenUI.transform.Find("Axe").transform.Find("req1").GetComponent<Text>();

        craftAxeBTN = toolsScreenUI.transform.Find("Axe").transform.Find("Button").GetComponent<Button>();
        craftAxeBTN.onClick.AddListener(delegate { CraftAnyItem(); }) ;


    }

    void OpenToolsCategory()
    {
        craftingScreenUI.SetActive(false);
        toolsScreenUI.SetActive(true);

    }

    void CraftAnyItem()
    {
        //adicionar item no inventorio



        //remover recursos do inventario








    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && !isOpen)
        {

            Debug.Log("i ta pressionado");
            craftingScreenUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            isOpen = true;

        }
        else if (Input.GetKeyDown(KeyCode.C) && isOpen)
        {
            craftingScreenUI.SetActive(false);
            toolsScreenUI.SetActive(false) ;
            Cursor.lockState = CursorLockMode.Locked;
            isOpen = false;
        }
    }
}
