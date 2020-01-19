#region Using Directives

using UnityEngine;

#endregion

public class FlowerDynamicPath : MonoBehaviour
{
    #region Member Variables

    public GameObject flower;

    #endregion

    #region Methods

    private void OnTriggerEnter(Collider entity)
    {
        if (entity.gameObject.tag == "Player")
        {
            flower.gameObject.SetActive(true);
            Destroy(this);
        }
    }

    #endregion
}