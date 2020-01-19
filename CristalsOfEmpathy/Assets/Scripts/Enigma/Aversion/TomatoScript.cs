#region Member Variables

using System;
using UnityEngine;
#endregion

public class TomatoScript : MonoBehaviour
{
    #region Member Variables
    #endregion

    #region Methods

    private void OnTriggerStay(Collider other)
    {
        print(other.gameObject.name);
    }

    #endregion
}
