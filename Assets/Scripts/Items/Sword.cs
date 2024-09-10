using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Items
{
    public Sword() : base(ItemCategory.Equippable) { }
    public override string GiveName()
    {
        return "Sword";
    }

    public override int MaxStacks()
    {
        return 1;
    }

    public override Sprite GiveItemImage()
    {
        return Resources.Load<Sprite>("Item Icons/SwordIcon");
    }
}
