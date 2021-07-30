using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Yeni Silah", menuName = "Mechanics/Items/Weapon Item")]
public class Weapon : Item
{
    public int Attack;
    public rarity rarity;
    public GameObject _3dOBJ;
    
}
public enum rarity
{
    Rare,
    Uncommon,
    Common
}