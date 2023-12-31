using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "new Tool Class", menuName = "Item/Misc")]
public class MiscItemClass : ItemClass
{
    [Header("Misc")]
    public MiscType miscType;

    public enum MiscType
    {
        Note,
    }

    public override ItemClass GetItem() { return this; }
    public override ToolClass GetTool() { return null; }
    public override MiscItemClass GetMiscItem() { return this; }
    public override ConsumableClass GetConsumable() { return null; }
}
