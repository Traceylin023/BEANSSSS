using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemClass : ScriptableObject
{
    [Header("Item")]
    public string itemName;
    public Sprite itemIcon;

    public abstract ItemClass GetItem();
    public abstract ToolClass GetTool();
    public abstract MiscItemClass GetMiscItem();
    public abstract ConsumableClass GetConsumable();

}
