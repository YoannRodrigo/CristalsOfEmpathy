#region Using Directives
using UnityEngine;
using UnityEngine.UI;
#endregion

public class InteractibleRunes : MonoBehaviour
{
    #region Member Variables
    public CuriosityEnigmaMenuManager managerRef;
    public RunesCounter runesRef;

    public GameObject nextRune;
    public GameObject victoryScreen;

    public GameObject nearParticlesSystem;
    public GameObject nearParticlesSystemHL;
    public GameObject nearParticlesSystemML;
    public GameObject nearParticlesSystemLL;

    public Image rune1;
    public Image rune1Filled;

    public Image rune2;
    public Image rune2Filled;

    public Image rune3;
    public Image rune3Filled;

    public Image rune4;
    public Image rune4Filled;

    public Image rune5;
    public Image rune5Filled;

    public Image rune6;
    public Image rune6Filled;
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
                    RunesProgression();
                }
            }
        }
    }

    private void CuriosityEnigmaProgression()
    {
        if (nextRune != null)
        {
            Destroy(this.gameObject);
            nextRune.SetActive(true);
            runesRef.runesCount++;
            Debug.Log("Object Touched");
            Debug.Log(runesRef.runesCount);
        }
    }

    private void RunesProgression()
    {
        switch (runesRef.runesCount)
        {
            case 1:
                rune1Filled.gameObject.SetActive(true);
                break;
            case 2:
                rune2Filled.gameObject.SetActive(true);
                break;
            case 3:
                rune3Filled.gameObject.SetActive(true);
                break;
            case 4:
                rune4Filled.gameObject.SetActive(true);
                break;
            case 5:
                rune5Filled.gameObject.SetActive(true);
                break;
            case 6:
                rune6Filled.gameObject.SetActive(true);
                victoryScreen.SetActive(true);
                managerRef.StartWaitToReturnCoroutine();
                break;
            default:
                break;
        }
    }

    //private void RuneDistanceFromCamera()
    //{
    //    //Augmenter le scale à mesure qu'on s'approche de (x=>0.5 y=>0.5)
    //    // X = 0.5 y = 0.5 correspond au centre de l'écran (caméra view)
    //    // L'idée serait d'instancier les systèmes de particules à mesure qu'on tend vers les valeurs 0.5 
    //    // 0.5 => intensité la plus lumineuse
    //    // 0.65 => Intensité lumineuse
    //    // 0.8 => Intensité légérement lumineuse
    //    // 1 => Intensité à peine visible
    //    // Au delà de 1 => R
      
    //    Vector3 viewPosition = Camera.main.WorldToViewportPoint(this.gameObject.transform.position);

    //    if (viewPosition.x == 0.4f)
    //    {
            
    //        Debug.Log("Center");
    //    }

    //    else if (viewPosition.x == 0.65f)
    //    {
           
    //        Debug.Log("HL");
    //    }

    //    else
    //    {
    //        nearParticlesSystem.SetActive(true);
    //        Debug.Log("Far");
    //    }
    //}

    // SOMETHING WENT WRONG HERE, ViewPosition need to updated each frame
    #endregion
}
