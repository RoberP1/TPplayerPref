using UnityEngine;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    public Slider volumeSlider;
    public Toggle muteToggle;
    private bool IsMutting;
    void Start() => LoadPref();
    private void LoadPref()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);
        muteToggle.isOn = PlayerPrefs.GetInt("Mute", 0) == 1;
    }

    public void ChangeVolume() {
        if (IsMutting)
        {
            IsMutting = false;
            return;
        }
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        muteToggle.isOn = false;
    }
public void OnMuteChange()
    {
        PlayerPrefs.SetInt("Mute", muteToggle.isOn ? 1 : 0);
        IsMutting = true;
        volumeSlider.value = muteToggle.isOn ? 0 : PlayerPrefs.GetFloat("Volume", 1f);
    }
    
}
