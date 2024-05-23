using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Linq;

//Credit to Brackeys youtube tutorial on Audio managers, as the majority of this code and learning how to use it was made by him.
[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0, 1)]
    public float volume = 1;
    [Range(-3, 3)]
    public float pitch = 1;
    public bool loop = false;
    public bool playOnAwake = false;
    public AudioSource source;

    public Sound()
    {
        volume = 1;
        pitch = 1;
        loop = false;
    }
}

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public Sound[] correctAffirmationSounds;
    public Sound[] wrongAffirmationSounds;

    public static AudioManager instance;

    private Sound currentSound;
    //AudioManager

    void Awake()
    {
        instance = this;

        foreach (Sound s in sounds)
        {
            if (!s.source)
                s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.playOnAwake = s.playOnAwake;
            if (s.playOnAwake)
                s.source.Play();

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

        s.source.Play();

        if(s.name != "Cat Celebration") 
        {
            currentSound = s;
        }
    }

    public void PlayAffirmation(string name)
    {
        Sound[] allAffirmations = correctAffirmationSounds.Concat(wrongAffirmationSounds).ToArray();
        Sound s = Array.Find(allAffirmations, sound => sound.name == name);
        Debug.Log(s.name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.clip = s.clip;
        s.source.Play();
    }

    public void Stop()
    {
        if(currentSound != null) 
        {
            currentSound.source.Pause();

        }
    }
}