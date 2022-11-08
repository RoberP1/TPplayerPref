using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider sliderController;
    public void OnChangeValue() =>
        audioSource.time = sliderController.value * audioSource.clip.length;
    private void Update() =>
        sliderController.value = audioSource.time / audioSource.clip.length;
}
