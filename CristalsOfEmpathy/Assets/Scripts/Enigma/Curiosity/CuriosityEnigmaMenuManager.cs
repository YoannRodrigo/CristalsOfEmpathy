#region Using Directives
using System.Collections;
using UnityEngine;
#endregion

public class CuriosityEnigmaMenuManager : MonoBehaviour
{
    #region Member Variables
    public LevelChanger levelChanger;
    public RunesCounter runesCounter;
    #endregion

    #region Methods
    public IEnumerator WaitToReturn()
    {
        yield return new WaitForSeconds(2);
        levelChanger.ChangeToLevelWithFade(0);
    }

    public void StartWaitToReturnCoroutine()
    {
        if (runesCounter.runesCount == 6)
        {
            Debug.Log("Entering coroutine");
            StartCoroutine("WaitToReturn");
        }
    }
    #endregion
}
