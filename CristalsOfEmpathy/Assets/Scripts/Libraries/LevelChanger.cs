#region Using Directives

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

#endregion

[RequireComponent(typeof(Animator))]
public class LevelChanger : MonoBehaviour
{
    #region Member Variables

    public static LevelChanger instance;

    private const float TIME_BEFORE_FADE_ENDED = 1f;
    private static readonly int isFadeOutNeeded = Animator.StringToHash("isFadeOutNeeded");

    private bool isFadeBegan;
    private float timeSinceFadeBegan;
    private int levelId;
    private Animator anim;

    #endregion

    #region Methods

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        DontDestroyOnLoad(gameObject);
    }

    public void FadeOut()
    {
        timeSinceFadeBegan = 0;
        anim.SetBool(isFadeOutNeeded, false);
        isFadeBegan = false;
    }
    
    public void ChangeToLevelWithFade(int levelId)
    {
        anim.SetBool(isFadeOutNeeded, true);
        this.levelId = levelId;
        isFadeBegan = true;
    }

    private void Update()
    {
        if (isFadeBegan)
        {
            timeSinceFadeBegan += Time.deltaTime;
            if (timeSinceFadeBegan > TIME_BEFORE_FADE_ENDED)
            {
                SceneManager.LoadScene(levelId);
            }
            
        }
    }

    #endregion
}