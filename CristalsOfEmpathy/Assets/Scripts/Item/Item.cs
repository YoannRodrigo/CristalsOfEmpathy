#region Using Directives
using UnityEngine;
#endregion

[CreateAssetMenu(fileName ="New Item", menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    #region Member Variables
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    #endregion
}
