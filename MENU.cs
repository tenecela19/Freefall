using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class MENU : MonoBehaviour
{
    public static bool touch;
    public AudioListener PlayerListener;
    public GameObject MuteIm;
    public GameObject SoundIm;
    public AudioMixer Audio;

    private void Start()
    {
        SoundIm.SetActive(!touch);
        MuteIm.SetActive(touch);
    }
    public void Sound() { 
        touch = !touch;
        SoundIm.SetActive(!touch);
        MuteIm.SetActive(touch);
        if (touch == true) AudioListener.volume = 0;
        else AudioListener.volume = 1;

    } 

    
}
