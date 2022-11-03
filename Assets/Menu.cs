using UnityEngine;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    public Slider volumeSlider;
    public Toggle muteToggle;
    void Start()
    {
        LoadPref();
    }

    private void LoadPref()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);
        muteToggle.isOn = PlayerPrefs.GetInt("Mute", 0) == 1;
    }

    public void ChangeVolume() =>
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
    public void OnMuteChange() => 
        PlayerPrefs.SetInt("Mute", muteToggle.isOn ? 1 : 0);    
    
}
