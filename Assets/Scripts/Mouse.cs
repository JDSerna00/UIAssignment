using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Mouse : MonoBehaviour
{
    public GameObject mouseItemUI;
    public Image mouseCursor;
    public ItemSlot itemSlot;
    public Image itemImage;
    public TextMeshProUGUI stacksText;

    private void Update()
    {
        transform.position = Input.mousePosition;
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            mouseCursor.enabled = false;
            mouseItemUI.SetActive(true);
        }
        else
        {
            mouseCursor.enabled = true;
            if (itemSlot.item != null)
            {
                mouseItemUI.SetActive(true);
            }
            else
            {
                mouseItemUI.SetActive(false);
            }
        }
    }

    public void SetUI()
    {
        stacksText.text = "" + itemSlot.stack;
        itemImage.sprite = itemSlot.item.GiveItemImage();
    }

    public void EmptySlot()
    {
        itemSlot = new ItemSlot(null,0);
    }
}
