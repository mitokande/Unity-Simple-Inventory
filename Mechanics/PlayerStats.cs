using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New PlayerStat",menuName ="Mechanics/Player/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public string PlayerName;
    public int Hunger;
    public int Health;
    public int Strength;
    public int attackpoints;
    public int defencepoints;
    public Weapon playerweapon;

}
