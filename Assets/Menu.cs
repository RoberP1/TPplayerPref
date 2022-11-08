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

        SavePref();
    }

    private void SavePref()
    {
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        PlayerPrefs.SetInt("Mute", muteToggle.isOn ? 1 : 0);
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
    public void ResetAudioTime() => PlayerPrefs.SetFloat("AudioTime", 0f);
    
    public void DefaultValues()
    {
        PlayerPrefs.DeleteKey("Volume");
        PlayerPrefs.DeleteKey("Mute");
        LoadPref();
    }

}
