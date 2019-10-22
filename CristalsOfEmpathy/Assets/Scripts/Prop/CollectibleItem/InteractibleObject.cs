#region Using Directives
using UnityEngine;
#endregion

public class InteractibleObject : InteractibleItem
{
    #region Member Variables
    public GameObject collectibleItem;
    #endregion

    #region Methods
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        Destroy(collectibleItem);
    //    }
    //}
    protected override void OnTouch()
    {
        Debug.Log(canBeTouch ? "Touch" : "Too far");

        if (canBeTouch)
        {
            Destroy(collectibleItem);
        }
    }
    #endregion
}
