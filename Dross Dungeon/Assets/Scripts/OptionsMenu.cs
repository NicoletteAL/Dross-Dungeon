using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    bool fullscreen = true;
    public AudioMixer mixer;
    public TextMeshProUGUI mode;

    public void ChangeMasterVolume(float sliderValue) {
        mixer.SetFloat("Master", Mathf.Log10(sliderValue) * 20);
    }
    public void ChangeSoundVolume(float sliderValue) {
        mixer.SetFloat("Sound", Mathf.Log10(sliderValue) * 20);
    }

    public void ChangeWindow() {
        fullscreen = !fullscreen;
        if (fullscreen) {
            Screen.fullScreenMode = FullScreenMode.Windowed;
            mode.text = "Current Mode: Windowed";
        }
        else {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
            mode.text = "Current Mode: Fullscreen";
        }
    }

    public void Escape() {
        SceneManager.LoadScene("Map");
    }
}
