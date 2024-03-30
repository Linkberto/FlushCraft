using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;


public class EquipSystem : MonoBehaviour
{
    public static EquipSystem Instance { get; set; }

    // UI
    public GameObject quickSlotsPanel;

    public List<GameObject> quickSlotsList = new List<GameObject>();

    public GameObject numbersHolder;

    public int selectedNumber = -1;
    public GameObject selectedItem;


    public GameObject toolHolder;

    public GameObject selectedItemModel;




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


    private void Start()
    {
        PopulateSlotList();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectQuickSlot(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectQuickSlot(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectQuickSlot(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectQuickSlot(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SelectQuickSlot(5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SelectQuickSlot(6);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SelectQuickSlot(7);
        }



        void SelectQuickSlot(int number)
        {
            if (checkIfSlotIsFull(number) == true)
            {

                if (selectedNumber != number)
                {
                    selectedNumber = number;


                    //desselecta o preview do item
                    if (selectedItem != null)
                    {
                        selectedItem.gameObject.GetComponent<InventoryItem>().isSelected = false;
                    }

                    selectedItem = GetSelectedItem(number);
                    selectedItem.GetComponent<InventoryItem>().isSelected = true;

                    SetEquippedModel(selectedItem);



                    // muda a cor
                    foreach (Transform child in numbersHolder.transform)
                    {
                        child.transform.Find("Text").GetComponent<Text>().color = Color.black;
                    }

                    Text toBeChanged = numbersHolder.transform.Find("number" + number).transform.Find("Text").GetComponent<Text>();
                    toBeChanged.color = Color.gray;
                }

                else //tentando selecionar o msm slot
                {
                    selectedNumber = -1; //nulo

                    if (selectedItem != null)
                    {
                        selectedItem.gameObject.GetComponent<InventoryItem>().isSelected = false;
                        selectedItem = null;
                    }

                    if (selectedItemModel != null)
                    {
                        DestroyImmediate(selectedItemModel.gameObject);
                        selectedItemModel = null;
                    }
                    //loop
                    foreach (Transform child in numbersHolder.transform)
                    {
                        child.transform.Find("Text").GetComponent<Text>().color = Color.black;
                    }

                }

            }

        }

        




        GameObject GetSelectedItem(int slotNumber)
        {
                return quickSlotsList[slotNumber-1].transform.GetChild(0).gameObject;
        }


        bool checkIfSlotIsFull(int slotNumber)
        {
            if (quickSlotsList[slotNumber-1].transform.childCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }





    }

    private void SetEquippedModel(GameObject selectedItem)
    {

        if (selectedItemModel != null)
        {
            DestroyImmediate(selectedItemModel.gameObject);
            selectedItemModel = null;
        }

        string selectedItemName = selectedItem.name.Replace("(Clone)", "");
         selectedItemModel = Instantiate(Resources.Load<GameObject>(selectedItemName + "_Model"),
            new Vector3(0.546f, 0.34f, 1.41f), Quaternion.Euler(-64.375f, 25.296f, -24.131f));
        selectedItemModel.transform.SetParent(toolHolder.transform, false);
    }

    private void PopulateSlotList()
    {
        foreach (Transform child in quickSlotsPanel.transform)
        {
            if (child.CompareTag("QuickSlot"))
            {
                quickSlotsList.Add(child.gameObject);
            }
        }
    }

    public void AddToQuickSlots(GameObject itemToEquip)
    {
        // Achar proximo slot livre

        GameObject availableSlot = FindNextEmptySlot();
        // Set transformacao do objeto
        itemToEquip.transform.SetParent(availableSlot.transform, false); 

        InventorySystem.Instance.ReCalculateList();

    }


    private GameObject FindNextEmptySlot()
    {
        foreach (GameObject slot in quickSlotsList)
        {
            if (slot.transform.childCount == 0)
            {
                return slot;
            }
        }
        return new GameObject();
    }

    public bool CheckIfFull()
    {

        int counter = 0;

        foreach (GameObject slot in quickSlotsList)
        {
            if (slot.transform.childCount > 0)
            {
                counter += 1;
            }
        }

        if (counter == 7)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
