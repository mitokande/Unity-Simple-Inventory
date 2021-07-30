using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlot
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
    public InventorySlot(int id,Item item,int amount)
    {
        this.slotid = id;
        this.item = item;
        this.amount = amount;
    }
    public void AddAmount(int amount)
    {
        this.amount += amount;
    }
    public void RemoveAmount(int amount)
    {
        this.amount -= amount;
    }
}
