using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    public void StartGame() {
        //Debug.Log("Not Yet!");
        SceneManager.LoadScene("Overworld");
    }

    public void Quit(){
        Application.Quit();
    }
}
