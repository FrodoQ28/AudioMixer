using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class CustomSlider : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixer;
    [SerializeField] private Toggle _muteButton;
    [SerializeField] private string _audioGroupName;
    [SerializeField] private Slider _slider;

    private float _maxValue = 1f;
    private float _minValue = 0.0001f;
    private float _currentValue = 1f;
    private bool _mute;

    private void Start()
    {
        _muteButton.onValueChanged.AddListener(ToggleMute);
        _slider.minValue = _minValue;
        _slider.maxValue = _maxValue;
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeVolume);
    }

    private void ChangeVolume(float value)
    {
        if (_mute)
        {
            _currentValue = value;
        }
        else
        {
            _currentValue = value;
            SetVolume(value);
        }
    }

    private void SetVolume(float value) =>
        _audioMixer.audioMixer.SetFloat(_audioGroupName, Mathf.Log(value) * 20);

    private void ToggleMute(bool mute)
    {
        _mute = mute;

        if (mute)
        {
            SetVolume(_minValue);
        }
        else
        {
            SetVolume(_currentValue);
        }
    }
}