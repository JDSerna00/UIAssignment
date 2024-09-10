using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
public class ItemPanel : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IDragHandler, IDropHandler, IPointerUpHandler
{
    public InventoryManager inventory;
    private Mouse mouse;
    public ItemSlot itemSlot;
    public Image itemImage;
    public TextMeshProUGUI stacksText;

    private bool click;

    public void PickupItem()
    {
        mouse.itemSlot = itemSlot;
        mouse.SetUI();
    }

    public void FadeOut()
    {
        itemImage.CrossFadeAlpha(0.3f,0.05f,true);
    }
    public void DropItem()
    {
        itemSlot.item = mouse.itemSlot.item;
        itemSlot.stack = mouse.itemSlot.stack;
        inventory.ClearSlot(mouse.itemSlot);
    }    

    public void SwapItem(ItemSlot slotA, ItemSlot slotB)
    {
        ItemSlot tempItem = new ItemSlot(slotA.item, slotA.stack);
        slotA.item = slotB.item;
        slotA.stack = slotB.stack;   

        slotB.item = tempItem.item;
        slotB.stack = tempItem.stack;
    }
    public void OnClick()
    {
        if(inventory != null)
        {
            mouse = inventory.mouse;
            
            if(mouse.itemSlot.item == null)
            {
                if (itemSlot.item != null)
                {
                    PickupItem();   
                    FadeOut();
                }
            }
            else
            {
                if(itemSlot == mouse.itemSlot)
                {
                    inventory.RefreshInventory();
                }
                else if (itemSlot.item == null)
                {
                    DropItem();
                    inventory.RefreshInventory();
                }
                else if(itemSlot.item.GiveName() != mouse.itemSlot.item.GiveName())
                {
                    SwapItem(itemSlot, mouse.itemSlot);
                    inventory.RefreshInventory();   
                }
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        eventData.pointerPress = this.gameObject;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        click = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (click)
        {
            OnClick();
            click = false;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        OnClick();
        click = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (click)
        {
            OnClick();
            click = false;
        }
    }
}
