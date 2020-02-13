using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public List<Portal> portals;
    public int portalIndex = 0;
    private void Awake(){instance = this;}

    private void Start()
    {
        LevelChanger.instance.FadeOut();
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
        o.transform.forward = direction;
        InterfaceManager.instance.GameUI(true);
        return o;
    }

}
