using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    public static InterfaceManager instance;
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

    [Header("References")]
    public SingleJoystick joystick;
    public GameObject pauseButton;
    public GameObject inventoryButton;


    public void ResetHUD()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
    
    public void GameUI(bool active)
    {
        joystick.gameObject.SetActive(active);
        pauseButton.SetActive(active);
        inventoryButton.SetActive(active);
    }
}
