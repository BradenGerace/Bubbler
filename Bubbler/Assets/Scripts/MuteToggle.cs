using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class MuteToggle : MonoBehaviour
{
    Toggle myToggle;

    private void Awake()
    {
        PlayerPrefs.GetFloat("Mute");
    }

    // Start is called before the first frame update
    void Start()
    {
        

        myToggle = GetComponent<Toggle>();
        if (AudioListener.volume == 0)
        {
            myToggle.isOn = false;
        }
    }

    public void ToggleAudioOnValueChange(bool audioIn)
    {
        if (audioIn)
        {
            PlayerPrefs.SetFloat("Mute", AudioListener.volume = 1);
        }
        else
        {
            PlayerPrefs.SetFloat("Mute", AudioListener.volume = 0);
        }
    }
}
