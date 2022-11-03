using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Subtitles : MonoBehaviour
{
    public SubtitleClass[] subtitlesArray;

    private void Awake()
    {
        subtitlesArray = Resources.LoadAll<SubtitleClass>("Subtitles");

        subtitlesArray.OrderBy(x => x.time);
    }
}
