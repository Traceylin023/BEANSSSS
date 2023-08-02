using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "new Tool Class", menuName = "Item/Consumable")]
public class ConsumableClass : ItemClass
{
    [Header("Comsumable")]
    public float infoAdded;

    public override ItemClass GetItem() { return this; }
    public override ToolClass GetTool() { return null; }
    public override MiscItemClass GetMiscItem() { return null; }
    public override ConsumableClass GetConsumable() { return this; }
}
