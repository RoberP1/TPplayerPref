using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class CreateSubtitle : MonoBehaviour
{
    public TextAsset textFile;

    List<string> lines = new List<string>();

    public List<SubtitleClass> subtitleClasses = new List<SubtitleClass>();

         // 2:52 song finish time
    public float previousTime = 2 * 60 + 52;

    private void Start()
    {
        lines = textFile.text.Split('\n').ToList();
    }
    public void CreateSubtitles()
    {
        for (int i = lines.Count - 1; i >= 0; i--)
        {
            //split time
            string time = lines[i].Split(']')[0];
            time = time.Replace("[", "");
            string[] timeArray = time.Split(':', '.');
            
            float timeFloat = float.Parse(timeArray[0]) * 60 + float.Parse(timeArray[1]) 
                                + float.Parse(timeArray[2]) / 100;

            //set time
            subtitleClasses[i].time = timeFloat;
            subtitleClasses[i].duration =  previousTime - timeFloat;

            //split and set text
            subtitleClasses[i].subtitle = lines[i].Split(']')[1];
            
            previousTime = timeFloat;
        }        
    }
}
