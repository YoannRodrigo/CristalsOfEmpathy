﻿#region Using Directives

using System;
using UnityEngine;

#endregion

public class SplashScreenToGame : MonoBehaviour
{
    #region Methods

    private void Start()
    {
        LevelChanger.instance.FadeOut();
    }

    private void Update()
    {
        timeSinceSceneStarted += Time.deltaTime;
        if (timeSinceSceneStarted > TIME_MAX_BEFORE_NEXT_SCENE) LevelChanger.instance.ChangeToLevelWithFade(FIRST_GAME_SCENE_ID);
    }

    #endregion

    #region Member Variables

    public LevelChanger levelChanger;

    private const float TIME_MAX_BEFORE_NEXT_SCENE = 2f;
    private const int FIRST_GAME_SCENE_ID = 2;
    private float timeSinceSceneStarted;

    #endregion
}