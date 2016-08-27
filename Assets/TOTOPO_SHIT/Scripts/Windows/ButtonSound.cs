using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource _UIAudioSource;
    public AudioClip _buttonClickAudio;

    public void PlayAudio ()
    {
        _UIAudioSource.clip = _buttonClickAudio;
        _UIAudioSource.Play();
    }
}
