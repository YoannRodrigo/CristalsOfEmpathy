#region Using Directives

using UnityEngine;

#endregion

public class DialogueGuardian : DialogueManager
{
    #region Methods

    private void Update()
    {
        if (isDialogueEndedGuardian)
            if (guardian != null)
            {
                guardian.transform.position -= new Vector3(2f * Time.deltaTime, 0, 0);
                Destroy(guardian.gameObject, 22f);
            }
    }

    #endregion

    #region Member Variables

    public GameObject guardian;
    public bool isDialogueEndedGuardian;

    #endregion
}