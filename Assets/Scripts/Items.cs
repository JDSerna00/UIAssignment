using UnityEngine;

[System.Serializable]   
public abstract class Items 
{
    public abstract string GiveName();
    public virtual int MaxStacks()
    {
        return 30;
    }

    public virtual Sprite GiveItemImage()
    {
        return Resources.Load<Sprite>("Item Icons/NoItem");
    }
}
