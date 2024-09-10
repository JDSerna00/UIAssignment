using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaScroll : Items
{
    public ManaScroll() : base(ItemCategory.Consumable){}
    
    public override string GiveName()
    {
        return "ManaScroll";
    }

    public override int MaxStacks()
    {
        return 10;
    }

    public override Sprite GiveItemImage()
    {
        return Resources.Load<Sprite>("Item Icons/ManaScrollItem");
    }
}
