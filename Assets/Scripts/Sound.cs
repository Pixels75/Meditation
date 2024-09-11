using UnityEngine;

[System.Serializable]
public class Sound
{
    public AudioClip audioClip;
    public string name;

    public Sound(AudioClip audioClip, string name)
    {
        this.audioClip = audioClip;
        this.name = name;
    }
}