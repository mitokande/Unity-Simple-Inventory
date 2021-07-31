using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Armor",menuName ="Mechanics/Items/Armor Item")]
public class Armor : Item
{
    public ArmorType armortype;
    public int DefencePoints;
}

public enum ArmorType
{
    Helmet,
    Body,
    Legs,
    Boots
}