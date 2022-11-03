using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Subtitle", menuName = "Subtitle")]
public class SubtitleClass : ScriptableObject
{
    public float time;
    public float duration;
    public string subtitle;
}
