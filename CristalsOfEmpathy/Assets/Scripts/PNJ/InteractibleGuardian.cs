#region Using Directives

using UnityEngine;

#endregion

public class InteractibleGuardian : InteractiblePnj
{
    #region Member Variables

    private bool isDialogueEndedGuardian;

    #endregion

    #region Methods

    public override void OnDialogEnded()
    {
        isDialogueEndedGuardian = true;
    }

    private void Update()
    {
        if (isDialogueEndedGuardian)
        {
            transform.position -= new Vector3(2f * Time.deltaTime, 0, 0);
            Destroy(gameObject, 22f);
        }
    }

    #endregion
}