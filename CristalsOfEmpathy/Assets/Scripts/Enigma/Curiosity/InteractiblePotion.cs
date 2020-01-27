#region Using Directives
using UnityEngine;
#endregion

public class InteractiblePotion : MonoBehaviour
{
    #region Member Variables
    public GameObject nextRune;
    public GameObject victoryScreen;
    public GameObject nearParticlesSystem;

    public LevelChanger levelChanger;
    #endregion

    #region Methods
    private void Awake()
    {
        Instantiate(nearParticlesSystem, transform);
    }
    private void Update()
    {
        TouchRotation();
    }

    private void TouchRotation()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(raycast, out RaycastHit raycastHit))
            {
                if (raycastHit.collider.gameObject == gameObject && !PauseMenu.IsOnPause())
                {
                    CuriosityEnigmaProgression();
                }
            }
        }
    }

    private void CuriosityEnigmaProgression()
    {
        if (nextRune != null)
        {
            Debug.Log("Object Touched");
            Destroy(this.gameObject);
            nextRune.SetActive(true);
        }

        else
        {
            Debug.Log("Finished");
            Destroy(this.gameObject);
            victoryScreen.SetActive(true);
            levelChanger.ChangeToLevelWithFade(0);
        }
    }

    #endregion
}
