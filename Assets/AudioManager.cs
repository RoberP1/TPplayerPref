using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;
    public TextMeshProUGUI subTitle;
    public subtitleClass[] subtitlesArray;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("Volume", 1f);
        audioSource.mute = PlayerPrefs.GetInt("Mute", 0) == 1;
        audioSource.time = PlayerPrefs.GetFloat("AudioTime", 0f);
        
        subtitlesArray = Resources.LoadAll<subtitleClass>("Subtitles");

        subtitlesArray.OrderBy(x => x.time);

        audioSource.Play();
    }

    private void Update()
    {
        //Debug.Log(audioSource.time);
        AudioSubTitles(audioSource.time);
        PlayerPrefs.SetFloat("AudioTime", audioSource.time);
    }

    public void AudioSubTitles(float time)
    {
        if (subtitlesArray.FirstOrDefault(x => x.time <= time && x.time + x.duration > time ) != null)
        {
            subTitle.text = subtitlesArray.FirstOrDefault(x => x.time <= time && x.time + x.duration > time).subtitle;
        }
        else
        {
            subTitle.text = "";
        }
    }
    
    private void OnDestroy()
    {
        
    }
}
