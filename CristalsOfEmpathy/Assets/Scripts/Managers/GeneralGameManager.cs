﻿#region Using Directives

using System;
using UnityEngine;

#endregion

public class GeneralGameManager : MonoBehaviour
{
    #region Member Variables

    public static GeneralGameManager instance;
    public void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public GameObject[] playerCharacterPrefabs;
    public GameObject cameraPrefab;
    public GameObject playerPrefab;

    public Transform playerSpawnerTransform;
    private static int _playerPrefabChoice = 0;
    private int nextPortalIndex = 0;
    #endregion

    #region Methods

    public void Go(string level, int portal = 0)
    {
        LevelChanger.instance.ChangeToLevelWithFade(level);
        nextPortalIndex = portal; 
    }

    public void OnLevelLoaded()
    {
        LevelManager.instance.portalIndex = nextPortalIndex;
        LevelManager.instance.SpawnPlayer();
    }

    public void SetPlayerPrefab(int playerPrefab)
    {
        _playerPrefabChoice = playerPrefab;
    }

    public int GetPlayerChoice()
    {
        return _playerPrefabChoice;
    }
    
    private void Start()
    {
        Time.timeScale = 1;
    }

    
    
    #endregion
}