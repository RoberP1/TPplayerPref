using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSubtitle : MonoBehaviour
{
    public TextAsset textFile;
    List<string> lines = new List<string>();
    public List<SubtitleClass> subtitleClasses = new List<SubtitleClass>();
    private void Start()
    {
        //textFile = Resources.Load<TextAsset>("Lyric");
    }
    public void CreateSubtitles()
    {
        lines = textFile.text.Split('\n').ToList();

        float previousTime = 2 * 60 + 52;

        for (int i = lines.Count - 1; i >= 0; i--)
        {
            //create in resources folder


            string time = lines[i].Split(']')[0];
            time = time.Replace("[", "");
            string[] timeArray = time.Split(':', '.');
            float timeFloat = float.Parse(timeArray[0]) * 60 + float.Parse(timeArray[1]) + float.Parse(timeArray[2]) / 100;
            subtitleClasses[i].time = timeFloat;
            subtitleClasses[i].duration =  previousTime - timeFloat;
            Debug.Log(timeFloat + " " + subtitleClasses[i].duration);
            subtitleClasses[i].subtitle = lines[i].Split(']')[1];
            Debug.Log(subtitleClasses[i].subtitle);
            previousTime = timeFloat;
        }        
    }
}
