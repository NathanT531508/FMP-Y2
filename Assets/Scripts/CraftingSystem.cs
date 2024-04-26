using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSystem : MonoBehaviour
{

    public GameObject craftingScreenUI;
    public GameObject toolScreenUI;

    public List<string> inventoryItemList = new List<string>();

    //Category Buttons
    Button toolsBTN;

    //Craft Buttons
    Button craftAxeBTN;

    //Requirement Text
    Text AxeReq1, AxeReq2;

    public bool isOpen;

    //all blueprint
    public Blueprint AxeBLP = new Blueprint("Axe", 2,"Stone", 3, "Stick", 3);

    //All Blueprints
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
    // Start is called before the first frame update
    void Start()
    {
        isOpen= false;

        toolsBTN = craftingScreenUI.transform.Find("ToolsButton").GetComponent<Button>();
        toolsBTN.onClick.AddListener(delegate { OpenToolsCategory(); });

        //Axe 
        AxeReq1 = toolScreenUI.transform.Find("Axe").transform.Find("req1").GetComponent<Text>();
        AxeReq2 = toolScreenUI.transform.Find("Axe").transform.Find("req2").GetComponent<Text>();

        craftAxeBTN = toolScreenUI.transform.Find("Axe").transform.Find("Button").GetComponent<Button>();
        craftAxeBTN.onClick.AddListener(delegate { CraftAnyItem(AxeBLP); });
    }


    void OpenToolsCategory()
    {
        craftingScreenUI.SetActive(false);
        toolScreenUI.SetActive(true);
    }

    void CraftAnyItem(Blueprint blueprintToCraft)
    {
        //adds item into inventory
        InventorySystem.Instance.AddToInventory(blueprintToCraft.itemName);
        if (blueprintToCraft.numOfRequirements == 1)
        {
            InventorySystem.Instance.RemoveItem(blueprintToCraft.Req1, blueprintToCraft.Req1amount);
        }
        else if (blueprintToCraft.numOfRequirements == 2)
        {

        }
        InventorySystem.Instance.RemoveItem(blueprintToCraft.Req1, blueprintToCraft.Req1amount);

        InventorySystem.Instance.RemoveItem(blueprintToCraft.Req2, blueprintToCraft.Req2amount);

        InventorySystem.Instance.RecalculateList();

            RefreshNeededItems();

        //remove resources from inv
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && !isOpen)
        {

            Debug.Log("c is pressed");
            Cursor.lockState = CursorLockMode.None;
            craftingScreenUI.SetActive(true);
            isOpen = true;

        }
        else if (Input.GetKeyDown(KeyCode.C) && isOpen)
        {
            Cursor.lockState = CursorLockMode.Locked;
            craftingScreenUI.SetActive(false);
            toolScreenUI.SetActive(false);
            isOpen = false;

            if (!InventorySystem.Instance.isOpen)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

    }


    private void RefreshNeededItems()
    {
        int stone_count = 0;
        int stick_count = 0;

        inventoryItemList = InventorySystem.Instance.itemList;

        foreach(string itemName in inventoryItemList)
        {
            switch (itemName)
            {
                case "Stone":

                    break;

                case "Stick":

                    break;
            }
        }

        AxeReq1.text = "3 Stone [" + stone_count + "]";
        AxeReq2.text = "3 Stone [" + stick_count + "]";

        if(stone_count >= 3 && stick_count >= 3)
        {
            craftAxeBTN.gameObject.SetActive(true);
        }
        else
        {
            craftAxeBTN.gameObject.SetActive(false);
        }
    }
}
