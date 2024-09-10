using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Items
{
    public Bow() : base(ItemCategory.Equippable) { }
    public override string GiveName()
    {
        return "Bow";
    }

    public override int MaxStacks()
    {
        return 1;
    }

    public override Sprite GiveItemImage()
    {
        return Resources.Load<Sprite>("Item Icons/BowIcon");
    }
}
