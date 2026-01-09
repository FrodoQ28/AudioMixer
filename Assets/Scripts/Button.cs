using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Button : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(ToggleMusic);
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveListener(ToggleMusic);
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