using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
    public List<Item> itemsList;

    public event Action OnItemListChanged;

    public Inventory()
    {
        itemsList = new List<Item>();

        Debug.Log($"Inventory items: {itemsList.Count}");
    }

    public void AddItem(Item item)
    {
        if (item.IsStackable())
        {
            bool itemInInventory = false;
            foreach(Item inventoryItem in itemsList){
                if (item.itemType == inventoryItem.itemType)
                {
                    itemInInventory = true;
                    inventoryItem.amount += item.amount;
                }
            }
            if (!itemInInventory) { itemsList.Add(item); }
        }
        else
        {
            itemsList.Add(item);
        }

        OnItemListChanged?.Invoke();
    }

    public void RemoveItem(Item item)
    {
        if (item.IsStackable())
        {
            Item itemInInventory = null;
            foreach(Item inventoryItem in itemsList){
                if (item.itemType == inventoryItem.itemType)
                {
                    inventoryItem.amount -= item.amount;
                    itemInInventory = inventoryItem;
                }
            }
            if (itemInInventory != null && itemInInventory.amount <= 0) 
            { 
                itemsList.Remove(itemInInventory); 
            }
        }
        else
        {
            itemsList.Remove(item);
        }

        OnItemListChanged?.Invoke();
    }

    public List<Item> GetItemsList()
    {
        return itemsList;
    }
}
