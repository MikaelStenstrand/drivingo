using UnityEngine;

[System.Serializable]
public class AudioFile {

    public string AudioName;
    public AudioClip AudioClip;

    [Range(0f,1f)]
    public float Volume;

    [HideInInspector]
    public AudioSource Source;

    public bool IsLooping;
    public bool PlayOnAwake;
}