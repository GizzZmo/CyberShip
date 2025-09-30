using UnityEngine;

public class UIAudioHandler : MonoBehaviour
{
    public void OnMenuClick()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        if (audioManager != null)
            audioManager.PlayMenuClick();
    }

    public void OnMenuHover()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        if (audioManager != null)
            audioManager.PlayMenuHover();
    }
}
