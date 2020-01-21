#region Using Directives

using UnityEngine;

#endregion

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    #region Member Variables

    public new string name = "New Item";
    public Sprite icon;
    public bool isDefaultItem;

    #endregion
}