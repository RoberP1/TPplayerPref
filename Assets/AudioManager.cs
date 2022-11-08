using System.Collections;
using UnityEngine;
using TMPro;
using System.Linq;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;
    public TextMeshProUGUI subTitle;
    public SubtitleClass[] subtitlesArray;
    public float timeBetweenSubtitles;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        
        LoadSettings();

        subtitlesArray = Resources.LoadAll<SubtitleClass>("Subtitles");

        subtitlesArray.OrderBy(x => x.time);

        audioSource.Play();
    }

    private void LoadSettings()
    {
        audioSource.volume = PlayerPrefs.GetFloat("Volume", 1f);
        audioSource.mute = PlayerPrefs.GetInt("Mute", 0) == 1;
        audioSource.time = PlayerPrefs.GetFloat("AudioTime", 0f);
    }

    private void Start() => StartCoroutine(Subtitle(0));
    public void SaveAudioTime() => 
        PlayerPrefs.SetFloat("AudioTime", audioSource.time);
    public void AudioSubTitles(float time)
    {
        //find subtitle
        SubtitleClass nextSubtitle = subtitlesArray.FirstOrDefault(x => 
                x.time <= time && x.time + x.duration >= time);
        
        subTitle.text = (nextSubtitle != null) ? nextSubtitle.subtitle : "";
   
        float duration = 
            (nextSubtitle != null) 
            ? nextSubtitle.time + nextSubtitle.duration - time 
            : 0.1f;
        
        StartCoroutine(Subtitle(timeBetweenSubtitles));
    }
    IEnumerator Subtitle(float time)
    {
        yield return new WaitForSeconds(time);
        AudioSubTitles(audioSource.time);
    }
    private void OnApplicationQuit() => SaveAudioTime();
}
