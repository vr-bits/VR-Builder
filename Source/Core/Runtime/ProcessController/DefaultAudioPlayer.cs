using UnityEngine;
using VRBuilder.Core.Configuration;

/// <summary>
/// Default process audio player.
/// </summary>
public class DefaultAudioPlayer : IProcessAudioPlayer
{
    private AudioSource audioSource;

    public DefaultAudioPlayer()
    {
        GameObject user = RuntimeConfigurator.Configuration.User.gameObject;

        audioSource = user.GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = user.AddComponent<AudioSource>();
        }
    }

    public DefaultAudioPlayer(AudioSource audioSource)
    {
        this.audioSource = audioSource;
    }

    /// <inheritdoc />
    public AudioSource FallbackAudioSource => audioSource;

    /// <inheritdoc />
    public bool IsPlaying => audioSource.isPlaying;

    /// <inheritdoc />
    public void PlayAudioClip(AudioClip audioClip, float volume = 1, float pitch = 1)
    {
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.pitch = pitch;
        audioSource.Play();
    }

    /// <inheritdoc />
    public void Reset()
    {
        audioSource.clip = null;
    }

    /// <inheritdoc />
    public void Stop()
    {
        audioSource.Stop();
    }
}