#region Using Directives

using UnityEngine;

#endregion

public class EndTutorialArea : MonoBehaviour
{
    #region Methods

    private void OnTriggerEnter(Collider entity)
    {
        if (entity.gameObject.tag == "Player" && tutorialManager.isQuestSubmitted)
            LevelChanger.instance.ChangeToLevelWithFade(3);
    }

    #endregion

    #region Member Variables

    public TutorialManager tutorialManager;

    #endregion
}