using System;
using UnityEngine;

[RequireComponent( typeof( AudioSource ) )]
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private Sound[] sounds;
    
    private AudioSource _audioSource;

    private void Awake()
    {
        if ( Instance == null )
        {
            Instance = this;
        }
        else if ( Instance != this )
        {
            Destroy( gameObject );
        }
        _audioSource = GetComponent<AudioSource>();
        Thunderstorm.ThunderStrike += () => { PlaySound("Thunder"); };
    }

    public void PlaySound( string clipName )
    {
        var sound = Array.Find( sounds, sound => sound.name == clipName );
        _audioSource.clip = sound.audioClip;
        _audioSource.Play();
    }
}
