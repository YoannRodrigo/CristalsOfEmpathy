#region Using Directives
using UnityEngine;

#endregion

public class GeneralGameManager : MonoBehaviour
{

    public static GeneralGameManager instance;
    
    
    public GameObject[] playerCharacterPrefabs;
    public GameObject cameraPrefab;
    public GameObject playerPrefab;

    private static int _playerPrefabChoice = 0;
    private int nextPortalIndex = 0;


    public bool hasPlayerHeardSpeach;
    [Header("PNJ Quests")] 
    public bool hasPlayerMetAgatha;
    public bool hasPlayerMetAlice;
    public bool hasPlayerMetAlberthus;
    public bool hasPlayerMetGarderner;
    public bool hasPlayerAcceptedApoQuest;
    public bool hasPlayerAcceptedFloristQuest;
    public bool hasPlayerAcceptedBartenderQuest;
    public bool hasPlayerAcceptedFishermanQuest;
    public bool hasPlayerGetWoods;
    public bool isApoQuestFinished;
    public bool isFloristQuestFinished;
    public bool isBartenderQuestFinished;
    public bool isFishermanQuestFinished;
    public int nbFlowerBuy;
    

    #region Methods

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
    }

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

    public void CallCamera(Transform target)
    {
        Instantiate(GeneralGameManager.instance.cameraPrefab, target.position, Quaternion.identity)
        .GetComponent<CameraMovement>().SetTarget(target);
    }
    
    #endregion
}