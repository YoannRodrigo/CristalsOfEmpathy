#region Using Directives
using System.Collections.Generic;
using UnityEngine;
#endregion

public class TutorialManager : MonoBehaviour
{
    //HANDLING TUTORIAL QUEST && BERLINGOTS COUNT
    #region Member Variables
    public bool isQuestActivated = false;
    public bool isQuestAchieved = false;

    public List<GameObject> berlingotsList = new List<GameObject>();
    #endregion

    #region Methods
    private void Update()
    {
        berlingotsList.RemoveAll(item => item == null);
    }

    public void BerlingotListRemover()
    {
        foreach (GameObject berlingotItem in berlingotsList)
        {
            if (berlingotItem.gameObject == null)
            {
                berlingotsList.Remove(berlingotItem);
            }
        }
    }

    public void TutorialQuestCompleted()
    {
        isQuestAchieved = true;
    }
    #endregion
}