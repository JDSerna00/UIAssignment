using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class InventoryManager : MonoBehaviour
{
    [SerializeReference] public List<ItemSlot> items = new List<ItemSlot>();

    [Space]
    [Header("Inventory Menu Components")]
    public GameObject inventoryMenu;
    public GameObject itemPanel;
    public GameObject itemPanelGrid;

    private List<ItemPanel> existingPanels = new List<ItemPanel>();

    [Space]
    public int inventorySize = 24;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < inventorySize; i++)
        {
            items.Add(new ItemSlot(null,0));
        }

        AddItem(new Apple(),3);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) 
        {
            if (inventoryMenu.activeSelf)
            {
                inventoryMenu.SetActive(false);
            }
            else
            {
                inventoryMenu.SetActive(true);
                RefreshInventory();
            }
        }

    }
    public int AddItem(Items item, int amount)
    {
        foreach (ItemSlot i in items)
        {
            if(i.item != null)
            {
                if (i.item.GiveName() == item.GiveName())
                {
                    if (amount > i.item.MaxStacks()-i.stack)
                    {
                        amount = i.item.MaxStacks()-i.stack;
                        i.stack = i.item.MaxStacks();
                    }
                    else
                    {
                        i.stack += amount;
                        if(inventoryMenu.activeSelf) RefreshInventory();
                        return 0;
                    }
                }
            }
        }

        foreach (ItemSlot i in items)
        {
            if(i.item == null)
            {
                if(amount > item.MaxStacks())
                {
                    i.item = item;
                    i.stack = item.MaxStacks();
                    amount = item.MaxStacks();
                }
                else
                {
                    i.item = item;
                    i.stack = amount;
                    if(inventoryMenu.activeSelf) RefreshInventory();
                    return 0;
                }
            }
        }

        Debug.Log($"No space in inventory for:{item.GiveName()}");
        if (inventoryMenu.activeSelf) RefreshInventory();
        return amount;
    }

    public void ClearSlot(ItemSlot slot)
    {
        slot.item = null;
        slot.stack = 0;
    }
    public void RefreshInventory()
    {
        existingPanels = itemPanelGrid.GetComponentsInChildren<ItemPanel>().ToList();

        if (existingPanels.Count < inventorySize)
        {
            int amountToCreate = inventorySize - existingPanels.Count;  
            for(int i = 0;i < amountToCreate;i++)
            {
                GameObject newPanel = Instantiate(itemPanel, itemPanelGrid.transform);
                ItemPanel itemPanelComponent = newPanel.GetComponent<ItemPanel>();
                if (itemPanelComponent != null)
                {
                    existingPanels.Add(itemPanelComponent);
                }
                else
                {
                    Debug.LogError("ItemPanel component missing on instantiated panel prefab.");
                }
            }
        }

        for (int index = 0; index < inventorySize; index++)
        {
            if (index >= items.Count)
            {
                Debug.LogError("Item index out of bounds at " + index);
                break;
            }

            ItemSlot currentItemSlot = items[index];
            ItemPanel currentPanel = existingPanels[index];

            if (currentPanel == null)
            {
                Debug.LogError("Panel is null at index " + index);
                continue;  // Skip to the next iteration to avoid errors
            }

            // Set the panel's name for debugging purposes
            string itemName = (index + 1).ToString();
            if (currentItemSlot.item != null) itemName += ": " + currentItemSlot.item.GiveName();
            else itemName += ": -";

            currentPanel.name = itemName + " Panel";

            // Assign the InventoryManager and ItemSlot to the panel
            currentPanel.inventory = this;
            currentPanel.itemSlot = currentItemSlot;

            Debug.Log("Assigning panel " + index + " with item " + itemName);

            // Update the panel UI elements
            if (currentItemSlot.item != null)
            {
                currentPanel.itemImage.gameObject.SetActive(true);
                currentPanel.itemImage.sprite = currentItemSlot.item.GiveItemImage();
                currentPanel.stacksText.gameObject.SetActive(true);
                currentPanel.stacksText.text = currentItemSlot.stack.ToString();
            }
            else
            {
                currentPanel.itemImage.gameObject.SetActive(false);
                currentPanel.stacksText.gameObject.SetActive(false);
            }
        }

        Debug.Log("Inventory refresh completed.");
       
     
    }
}
