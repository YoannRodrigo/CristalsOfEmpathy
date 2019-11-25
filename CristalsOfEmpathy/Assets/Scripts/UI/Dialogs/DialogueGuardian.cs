#region Using Directives
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#endregion

public class DialogueGuardian : DialogueManager
{
    #region Member Variables
    public BarPointsHandler barPointsHandler;

    public GameObject guardian;

    public bool isDialogueEndedGuardian;
    #endregion

    #region Methods
  
    private void Update()
    {
        if (isDialogueEndedGuardian)
        {
            if (guardian != null)
            {
                guardian.transform.position -= new Vector3(2f * Time.deltaTime, 0, 0);
                Destroy(guardian.gameObject, 22f);
            }
        }
    }
    
    #endregion
}