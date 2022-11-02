using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Settings : MonoBehaviour
{
    public bool isMute;
    void Start()
    {
        isMute = PlayerPrefs.GetInt("Mute", 0) == 1;
        AudioListener.volume = PlayerPrefs.GetFloat("Volume", 1f);
    }
}
