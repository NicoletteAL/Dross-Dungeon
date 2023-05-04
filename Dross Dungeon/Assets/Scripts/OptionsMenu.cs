using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    bool fullscreen = true;
    public AudioMixer mixer;
    public TextMeshProUGUI mode;
    public TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;

    void Start() {
        resolutions = Screen.resolutions;
        for(int i = 0; i<resolutions.Length; i++){
            string resolutionString = resolutions[i].width.ToString() + "x" + resolutions[i].height.ToString();
            resolutionDropdown.options.Add(new TMP_Dropdown.OptionData(resolutionString));

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height){
                resolutionDropdown.value = i;
            }

        }
    }

    public void SetResolution() {
        if (fullscreen) {
            Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, true);

        }
        else {
            Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, false);
        }
    }

    public void ChangeMasterVolume(float sliderValue) {
        mixer.SetFloat("Master", Mathf.Log10(sliderValue) * 20);
    }
    public void ChangeSoundVolume(float sliderValue) {
        mixer.SetFloat("Sound", Mathf.Log10(sliderValue) * 20);
    }
    public void ChangeMusicVolume(float sliderValue) {
        mixer.SetFloat("Music", Mathf.Log10(sliderValue) * 20);
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
        SceneManager.LoadScene("Overworld");
    }
}
