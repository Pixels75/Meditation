using System;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            DontDestroyOnLoad( gameObject );
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
    }

    private void Update()
    {
        if ( SceneManager.GetActiveScene().buildIndex != 0 ) return;
        var audioManagers = FindObjectsOfType<AudioManager>();
        foreach ( var m in audioManagers )
        {
            if ( m == this ) continue;
            Destroy( m.gameObject );
        }
    }

    public void PlaySound( string clipName )
    {
        var sound = Array.Find( sounds, sound => sound.name == clipName );
        sound.source.Play();
    }
}
