using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    public static InterfaceManager instance;
    void Awake() {instance = this;}

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
