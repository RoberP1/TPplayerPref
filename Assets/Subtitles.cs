using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Subtitles : MonoBehaviour
{
    public subtitleClass[] subtitlesArray;

    private void Awake()
    {
        subtitlesArray = Resources.LoadAll<subtitleClass>("Subtitles");

        subtitlesArray.OrderBy(x => x.time);
    }
}
