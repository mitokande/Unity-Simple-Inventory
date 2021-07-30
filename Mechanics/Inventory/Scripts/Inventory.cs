using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Yeni Envanter",menuName ="Mekanikler/Yeni Envanter")]
public class Inventory : ScriptableObject
{
    public InventorySlot[] itemlist = new InventorySlot[24];

    public void AddItem(Item item, int amount)
    {
        for (int i = 0; i < itemlist.Length; i++)
        {
            if(itemlist[i].slotid == item.ID && item.stackable)
            {
                itemlist[i].AddAmount(amount);
                return;
            }
        }
        EmptySlot(item, amount);
    }
    public InventorySlot EmptySlot(Item item,int amount)
    {
        for (int i = 0; i < itemlist.Length; i++)
        {
            if(itemlist[i].slotid == 0)
            {
                itemlist[i].UpdateSlot(item.ID, item, amount);
                return itemlist[i];
            }
            
        }
        return null;
    }
    public void SwapItem(InventorySlot slot1, InventorySlot slot2)
    {
        InventorySlot temp = new InventorySlot(slot2.slotid, slot2.item, slot2.amount);
        slot2.UpdateSlot(slot1.slotid, slot1.item, slot1.amount);
        slot1.UpdateSlot(temp.slotid, temp.item, temp.amount);
    }
}

