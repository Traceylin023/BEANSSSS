using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class InventorySystem : MonoBehaviour
{
   private Dictionary<InventoryItemData, InventoryItem> m_itemDictionaty;
   public List<InventoryItem> inventory { get; private set; }

   private void Awake()
   {
    inventory = new List<InventoryItem>();
    m_itemDictionaty = new Dictionary<InventoryItemData, InventoryItem>();
   }

    public InventoryItem Get(InventoryItemData referenceData)
    {
        if (m_itemDictionaty.TryGetValue(referenceData, out InventoryItem value))
        {
            return value;
        }
        return null;
    }

   public void Add(InventoryItemData referenceData)
   {
        if(m_itemDictionaty.TryGetValue(referenceData, out InventoryItem value))
        {
            value.AddToStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(referenceData);
            inventory.Add(newItem);
            m_itemDictionaty.Add(referenceData, newItem);
        }
   }

   public void Romove(InventoryItemData referenceData)
   {
        if(m_itemDictionaty.TryGetValue(referenceData, out InventoryItem value))
        {
            value.RemoveFromStack();

            if(value.stackSize == 0)
            {
                inventory.Reomve(value);
                m_itemDictionaty.Reomve(referenceData);
            }
        }
   }
}

[Serializable]
public class InventoryItem
{
    public InventoryItemData data { get; private set; }
    public int stackSize { get; private set; }

    public InventoryItem(InventoryItemData source)
    {
        data = source;
        AddToStack(); 
    }

    public void AddToStack()
    {
        stackSize++;
    }

    public void RemoveFromStack()
    {
        stackSize--;
    }
}
*/ 