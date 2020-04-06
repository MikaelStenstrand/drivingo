using System;
using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;
    public AudioFile[] audioFiles;
    private float timeToReset;
    private bool timerIsSet = false;
    private string tmpName;
    private float tmpVol;
    private bool isLowered = false;
    private bool fadeOut = false;
    private bool fadeIn = false;
    private string fadeInUsedString;
    private string fadeOutUsedString;


    void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        foreach (var audioFile in audioFiles) {
            audioFile.Source = gameObject.AddComponent<AudioSource>();
            audioFile.Source.clip = audioFile.AudioClip;
            audioFile.Source.volume = audioFile.Volume;
            audioFile.Source.loop = audioFile.IsLooping;
            if (audioFile.PlayOnAwake) {
                audioFile.Source.Play();
            }
        }
    }

    public static void PlayAudio(string name) {
        AudioFile soundFile = Array.Find(instance.audioFiles, AudioFile => AudioFile.AudioName == name);
        if (soundFile == null) {
            Debug.LogError("Sound name" + name + "not found!");
            return;
        } else {
            soundFile.Source.Play();
        }
    }

    public static void StopAudio(String name) {
        AudioFile s = Array.Find(instance.audioFiles, AudioFile => AudioFile.AudioName == name);
        if (s == null) {
            Debug.LogError("Sound name" + name + "not found!");
            return;
        } else {
            s.Source.Stop();
        }
    }

    public static void PauseAudio(String name) {
        AudioFile s = Array.Find(instance.audioFiles, AudioFile => AudioFile.AudioName == name);
        if (s == null) {
            Debug.LogError("Sound name" + name + "not found!");
            return;
        } else {
            s.Source.Pause();
        }
    }

    public static void UnPauseAudio(String name) {
        AudioFile s = Array.Find(instance.audioFiles, AudioFile => AudioFile.AudioName == name);
        if (s == null) {
            Debug.LogError("Sound name" + name + "not found!");
            return;
        } else {
            s.Source.UnPause();
        }
    }

    public static void LowerVolume(String name, float _duration) {
        if (instance.isLowered == false) {
            AudioFile s = Array.Find(instance.audioFiles, AudioFile => AudioFile.AudioName == name);
            if (s == null) {
                Debug.LogError("Sound name" + name + "not found!");
                return;
            } else {
                instance.tmpName = name;
                instance.tmpVol = s.Volume;
                instance.timeToReset = Time.time + _duration;
                instance.timerIsSet = true;
                s.Source.volume = s.Source.volume / 3;
            }
            instance.isLowered = true;
        }
    }

    public static void FadeOut(String name, float duration) {
        instance.StartCoroutine(instance.IFadeOut(name, duration));
    }

    public static void FadeIn(String name, float targetVolume, float duration) {
        instance.StartCoroutine(instance.IFadeIn(name, targetVolume, duration));
    }

    private IEnumerator IFadeOut(String name, float duration) {
        AudioFile s = Array.Find(instance.audioFiles, AudioFile => AudioFile.AudioName == name);
        if (s == null) {
            Debug.LogError("Sound name" + name + "not found!");
            yield return null;
        } else {
            if (fadeOut == false) {
                fadeOut = true;
                float startVol = s.Source.volume;
                fadeOutUsedString = name;
                while (s.Source.volume > 0) {
                    s.Source.volume -= startVol * Time.deltaTime / duration;
                    yield return null;
                }
                s.Source.Stop();
                yield return new WaitForSeconds(duration);
                fadeOut = false;
            } else {
                Debug.Log("Could not handle two fade outs at once : " + name + " , " + fadeOutUsedString + "! Stopped the music " + name);
                StopAudio(name);
            }
        }
    }

    public IEnumerator IFadeIn(string name, float targetVolume, float duration) {
        AudioFile s = Array.Find(instance.audioFiles, AudioFile => AudioFile.AudioName == name);
        if (s == null) {
            Debug.LogError("Sound name" + name + "not found!");
            yield return null;
        } else {
            if (fadeIn == false) {
                fadeIn = true;
                instance.fadeInUsedString = name;
                s.Source.volume = 0f;
                s.Source.Play();
                while (s.Source.volume < targetVolume) {
                    s.Source.volume += Time.deltaTime / duration;
                    yield return null;
                }

                yield return new WaitForSeconds(duration);
                fadeIn = false;
            } else {
                Debug.Log("Could not handle two fade ins at once: " + name + " , " + fadeInUsedString + "! Played the music " + name);
                StopAudio(fadeInUsedString);
                PlayAudio(name);
            }
        }
    }

    private void ResetVol() {
        AudioFile s = Array.Find(instance.audioFiles, AudioFile => AudioFile.AudioName == tmpName);
        s.Source.volume = tmpVol;
        isLowered = false;
    }

    private void Update() {
        if (Time.time >= timeToReset && timerIsSet) {
            ResetVol();
            timerIsSet = false;
        }
    }
}
