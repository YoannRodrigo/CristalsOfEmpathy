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
    public void Awake()
    {
        if(instance == null)
        {
            transform.parent = null;
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        anim = GetComponent<Animator>();
    }

    private const float TIME_BEFORE_FADE_ENDED = 1f;
    private static readonly int isFadeOutNeeded = Animator.StringToHash("isFadeOutNeeded");

    private bool isFadeBegan;
    private float timeSinceFadeBegan;

    private int levelId;
    private string levelName;

    private Animator anim;

    #endregion

    #region Methods

    private void Start()
    {
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
        levelName = "";
        isFadeBegan = true;
    }
    public void ChangeToLevelWithFade(string levelName)
    {
        anim.SetBool(isFadeOutNeeded, true);
        levelId = -1;
        this.levelName = levelName;
        isFadeBegan = true;
    }

    private void Update()
    {
        if (isFadeBegan)
        {
            timeSinceFadeBegan += Time.deltaTime;
            if (timeSinceFadeBegan > TIME_BEFORE_FADE_ENDED)
            {
                if(levelId > -1) SceneManager.LoadScene(levelId);
                else if(levelName != "") SceneManager.LoadScene(levelName);
            }
        }
    }
    #endregion
}