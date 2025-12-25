using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundMaster : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Toggle _muteButton;
    [SerializeField] private AudioSource _audioBackground;

    private float _minVolume = -80f;
    private float _lastVolume = 0f;
    private bool _isEnableMute = false;

    private string _masterGroupVolumeName = "MasterVolume";
    private string _buttonGroupVolumeName = "ButtonsVolume";
    private string _backgroundGroupVolumeName = "BackgroundVolume";

    public void ToggleMute(bool isMute)
    {
        if (isMute)
        {
            _mixer.audioMixer.GetFloat(_masterGroupVolumeName, out _lastVolume);
            _mixer.audioMixer.SetFloat(_masterGroupVolumeName, _minVolume);

            _isEnableMute = true;
        }
        else
        {
            _mixer.audioMixer.SetFloat(_masterGroupVolumeName, _lastVolume);

            _isEnableMute = false;
        }
    }

    public void ChangeMasterVolume(float volume) =>
        ChangeVolume(_masterGroupVolumeName, volume);

    public void ChangeButtonVolume(float volume) =>
        ChangeVolume(_buttonGroupVolumeName, volume);

    public void ChangeBackgroundVolume(float volume) =>
        ChangeVolume(_backgroundGroupVolumeName, volume);

    private void ChangeVolume(string groupName, float volume)
    {
        if (_isEnableMute)
            _muteButton.isOn = false;

        _mixer.audioMixer.SetFloat(groupName, Mathf.Log(volume) * 20);
    }
}