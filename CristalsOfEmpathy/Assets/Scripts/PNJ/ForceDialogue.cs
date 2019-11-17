#region Using Directives
using UnityEngine;
#endregion
public class ForceDialogue : MonoBehaviour
{
    #region Member Variables

    public bool isNeededToBeDestroyed;
    public InteractiblePnj interactiblePnj;
    #endregion

    #region Methods
    private void OnTriggerEnter(Collider other)
    {
        interactiblePnj.StartDialogue();
        if (isNeededToBeDestroyed)
        {
            Destroy(gameObject);
        }
    }
    #endregion
}
