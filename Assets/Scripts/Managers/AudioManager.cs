using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private Sound[] sounds;

    private void Awake()
    {
        // Singleton
        if ( Instance == null )
        {
            Instance = this;
        }
        else if ( Instance != this )
        {
            Destroy( gameObject );
        }

        foreach ( var sound in sounds )
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.audioClip;
            sound.source.volume = sound.volume;
        }
        Thunderstorm.ThunderStrike += () => { PlaySound("Thunder"); };
    }

    public void PlaySound( string clipName )
    {
        var sound = Array.Find( sounds, sound => sound.name == clipName );
        sound.source.Play();
    }
}
