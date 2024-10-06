using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] MusicSounds;
    public Sound[] SFXSounds;
    public AudioSource MusicSource;
    public AudioSource SFXSource;
    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    
    public void PlayMusic(string name)
    {
        Sound s = System.Array.Find(MusicSounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        else
        {
            MusicSource.clip = s.clip;
            MusicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = System.Array.Find(SFXSounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        else
        {
            SFXSource.clip = s.clip;
            SFXSource.PlayOneShot(s.clip);
        }
    }

    public void StopMusic()
    {
        MusicSource.Stop();
    }

    public void StopSFX()
    {
        SFXSource.Stop();
    }

    public void StopAll()
    {
        MusicSource.Stop();
        SFXSource.Stop();
    }
}
