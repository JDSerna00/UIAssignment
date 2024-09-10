using UnityEngine;

[System.Serializable]

public enum ItemCategory
{
    Consumable,
    Equippable
}
public abstract class Items 
{
    protected ItemCategory category;

    public Items(ItemCategory category)
    {
        this.category = category;
    }
    public abstract string GiveName();
    public virtual int MaxStacks()
    {
        return 30;
    }

    public virtual Sprite GiveItemImage()
    {
        return Resources.Load<Sprite>("Item Icons/NoItem");
    }
    public ItemCategory GetCategory()
    {
        return category;
    }
}
