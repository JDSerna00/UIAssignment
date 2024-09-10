using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : Items
{
    public Cheese() : base(ItemCategory.Consumable) { }
    public override string GiveName()
    {
        return "Cheese";
    }

    public override int MaxStacks()
    {
        return 15;
    }

    public override Sprite GiveItemImage()
    {
        return Resources.Load<Sprite>("Item Icons/CheeseIcon");
    }
}
