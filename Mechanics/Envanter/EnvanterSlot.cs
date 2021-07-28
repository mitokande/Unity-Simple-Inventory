using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnvanterSlot 
{
    public int slotid;
    public Item item;
    public int amount;
    public void UpdateSlot(int id, Item item, int amount)
    {
        this.slotid = id;
        this.item = item;
        this.amount = amount;
    }
    public EnvanterSlot(int id,Item item,int amount)
    {
        this.slotid = id;
        this.item = item;
        this.amount = amount;
    }
    public void AddAmount(int amount)
    {
        this.amount += amount;
    }
}
