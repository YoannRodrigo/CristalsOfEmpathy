#region Using Directives

using UnityEngine;
using UnityEngine.SceneManagement;

#endregion
public class SplashScreenToGame : MonoBehaviour
{
    #region Member Variables

    private const float TIME_MAX_BEFORE_NEXT_SCENE = 2f;
    private float timeSinceSceneStarted;
    
    #endregion
    
    #region Methods
    
    private void Update()
    {
        timeSinceSceneStarted += Time.deltaTime;
        if (timeSinceSceneStarted > TIME_MAX_BEFORE_NEXT_SCENE)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    
    #endregion
}
