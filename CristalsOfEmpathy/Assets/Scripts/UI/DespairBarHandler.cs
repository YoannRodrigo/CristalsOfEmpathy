#region Using Directives

using UnityEngine;

#endregion

public class DespairBarHandler : MonoBehaviour
{
    #region Member Variables

    public int _despairBarPoints; /* Pourquoi un "public" ? */

    #endregion

    #region Methods

    private void Start()
    {
        _despairBarPoints = 0; /* On remets la variable à zéro à chaque chargement de scène ? */
    }

    #endregion
}