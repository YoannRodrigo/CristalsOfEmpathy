#region Using Directives
using UnityEngine;
#endregion

public class EndTutorialArea : MonoBehaviour
{
    #region Member Variables
    public LevelChanger levelChanger;
    public TutorialManager tutorialManager;
    #endregion

    #region Methods
    private void OnTriggerEnter(Collider entity)
    {
        if (entity.gameObject.tag == "Player" && tutorialManager.isQuestSubmitted)
        {
            levelChanger.ChangeToLevelWithFade(3);
        }
    }
    #endregion
}

