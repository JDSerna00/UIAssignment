
using UnityEngine;
[System.Serializable]
public class ItemSlot
{
    public Items item;
    public string name;
    public int stack;

    public ItemSlot(Items newItem, int newStacks)
    {
        item = newItem;
        stack = newStacks;
    }
}
