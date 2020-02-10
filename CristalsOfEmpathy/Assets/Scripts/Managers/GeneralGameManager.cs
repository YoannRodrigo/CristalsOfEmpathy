#region Using Directives

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
    #endregion

    #region Methods

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