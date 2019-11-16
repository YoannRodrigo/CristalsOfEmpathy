#region Using Directives
using UnityEngine;
#endregion

public class TutorialQuest : MonoBehaviour
{
    //CONDITION OF BEGIN => DIALOGUE MANAGER ACCEPT OK
    //CONDITION OF FINISH => BERLINGOTS ITEM DESTROYED = 6
    //DO NOT DELETE ! MAY BE USED LATER FOR QUEST MANAGEMENT IMPROVEMENT

    #region Member Variables

    #endregion

    #region Events

    public delegate void OnQuestBegin();
    public delegate void OnQuestFinished();

    public delegate void OnBerlingotsPickedUp();

    public OnQuestBegin onQuestBeginCallback;
    public OnQuestFinished onQuestFinishedCallback;

    public OnBerlingotsPickedUp onBerlingotsPickedUpCallback;

    #endregion

    #region Methods
   
    #endregion
}