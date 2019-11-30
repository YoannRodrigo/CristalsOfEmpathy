using UnityEngine;

public class SoundManangerMainMenu : MonoBehaviour
{
    private void Start()
    {
        AkSoundEngine.PostEvent("MainMenuOpen", gameObject);
    }

    public void ButtonPressedEvent()
    {
        AkSoundEngine.PostEvent("ButtonPressed", gameObject);
    }
}
