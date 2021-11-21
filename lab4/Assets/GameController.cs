using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public AudioSource curAudio;
    public AudioClip[] allAudios;
    public Slider slider;
    public Toggle toggle;
    public Dropdown dropdown;

    // Start is called before the first frame update
    void Start() {
        curAudio.volume = slider.value;
        curAudio.mute = !toggle.isOn;
        curAudio.clip = allAudios[dropdown.value];
    }

    // Update is called once per frame
    void Update() {   
        // curAudio.volume = slider.value;
    }

    public void setClip() {
        curAudio.Stop();
        curAudio.clip = allAudios[dropdown.value];
        curAudio.Play();
    }

    public void setVolume() {
        curAudio.volume = slider.value;
    }

    public void setMute() {
        curAudio.mute = !toggle.isOn;
    }
}
