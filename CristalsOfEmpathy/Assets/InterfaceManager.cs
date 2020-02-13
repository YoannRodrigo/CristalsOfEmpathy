using UnityEngine;
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

    public void GameUI(bool active)
    {
        joystick.gameObject.SetActive(active);
        pauseButton.SetActive(active);
        inventoryButton.SetActive(active);
    }
}
