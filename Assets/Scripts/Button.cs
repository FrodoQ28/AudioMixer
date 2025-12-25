using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Button : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void ToggleMusic(bool enable)
    {
        if (enable)
        {
            _audioSource.Play();
        }
        else
        {
            _audioSource.Stop();
        }
    }
}