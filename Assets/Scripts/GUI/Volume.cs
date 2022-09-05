using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField] private List<AudioSource> _audioSources;
    [SerializeField] private Slider _volumeSlider;

    private void OnEnable()
    {
        _volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    private void OnDisable()
    {
        _volumeSlider.onValueChanged.RemoveListener(ChangeVolume);
    }

    private void ChangeVolume(float sliderValue)
    {
        foreach(var source in _audioSources)
            source.volume = sliderValue;
    }

}
