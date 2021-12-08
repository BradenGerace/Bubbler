using UnityEngine;
using System;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;
    public static AudioListener audioListener;
    public static float volume;

    [SerializeField] Toggle audioToggle;

    private void Awake()
    {
        PlayerPrefs.GetFloat("Mute");

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        
    }

    private void Start()
    {
        Play("Theme");

        if (AudioListener.volume == 0)
        {
            audioToggle.isOn = false;
        }
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void MuteAudio ()
    {
        PlayerPrefs.SetFloat("Mute", AudioListener.volume = 0f);
    }
}
