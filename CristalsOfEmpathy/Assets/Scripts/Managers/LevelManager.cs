using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private void Awake(){instance = this;}

    public List<Portal> portals;
    [HideInInspector]  public int portalIndex = 0;
    [HideInInspector]  public PlayerMovement player;
    private readonly List<int> sceneGameId =new List<int>{2,3,8,9,10,11,13};
    private void Start()
    {
        LevelChanger.instance.FadeOut();
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            InterfaceManager.instance.ResetHUD();
        }
        GeneralGameManager.instance.OnLevelLoaded();
    }

    public void SpawnPlayer()
    {
        GameObject p = AppearOnPortal();
        GeneralGameManager.instance.CallCamera(p.transform);
    }

    public GameObject AppearOnPortal()
    {
        return Spawn(GetCurrentPortal().spawn, GetCurrentPortal().GetDirection());
    }

    public Portal GetCurrentPortal()
    {
        return portals[portalIndex];
    }

    public GameObject Spawn(Vector3 position = new Vector3(), Vector3 direction = new Vector3())
    {
        GameObject o = Instantiate(GeneralGameManager.instance.playerPrefab, position, Quaternion.identity);
        player = o.GetComponent<PlayerMovement>();
        o.transform.forward = direction;
        InterfaceManager.instance.GameUI(true);
        return o;
    }

}
