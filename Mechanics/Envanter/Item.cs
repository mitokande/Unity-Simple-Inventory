using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Food,
    Armor,
    Misc
}

[System.Serializable]
public class Item : ScriptableObject
{
    public int ID;
    public string ItemName;
    public Sprite Icon;
    public ItemType type;
    public bool stackable;
}
