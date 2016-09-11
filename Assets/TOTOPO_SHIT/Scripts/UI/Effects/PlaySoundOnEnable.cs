using UnityEngine;

public class PlaySoundOnEnable : MonoBehaviour
{
    public AudioSource _UIAudioSource;
    public AudioClip _audioClip;

    public void OnEnable ()
    {
        _UIAudioSource.clip = _audioClip;
        _UIAudioSource.Play();
    }
}
