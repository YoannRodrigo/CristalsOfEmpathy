#region Using Directives

using System;
using UnityEngine;

#endregion

public class BarPointsHandler : MonoBehaviour
{
    #region Member Variables

    private static BarPointsHandler _instance;
    private static int _loveBarPoints = 0;
    private static int _fearBarPoints = 0;
    private static int _curiosityBarPoints = 0;
    private static int _aversionBarPoints =0;

    public BarPointsHandler GetInstance()
    {
        return _instance;
    }

    private void Awake()
    {
        if (_instance != null && _instance != this) 
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }


    #endregion

    #region Methods


    #endregion
}