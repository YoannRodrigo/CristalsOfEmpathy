#region Using Directives
using UnityEngine;
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