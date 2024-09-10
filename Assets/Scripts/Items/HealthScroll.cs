using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScroll : Items
{
    public HealthScroll() : base(ItemCategory.Consumable) { }
    public override string GiveName()
    {
        return "HealthScroll";
    }

    public override int MaxStacks()
    {
        return 10;
    }

    public override Sprite GiveItemImage()
    {
        return Resources.Load<Sprite>("Item Icons/HealthScrollItem");
    }
}
