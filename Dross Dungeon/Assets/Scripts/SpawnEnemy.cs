using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SpawnEnemy : MonoBehaviour
{
    int num;
    public TextMeshProUGUI alert;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // every step triggers a dice roll for combat
         if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) {
            num = Random.Range(0, 10);
            Debug.Log(num);
            if (num < 3) {
                alert.text = "Enemy!";
                
                SceneManager.LoadScene("Battle");
            }
            else{
                alert.text = "";
            }
        }  
        if (Input.GetKeyDown(KeyCode.Q)) {
            Application.Quit();
        } 
    }
}
