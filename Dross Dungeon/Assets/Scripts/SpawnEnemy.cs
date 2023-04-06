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
    public TextMeshProUGUI stats;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        stats.text = "HP: " + player.hp + "/" + player.max + "\nGold: " + player.gold;
    }

    // Update is called once per frame
    void Update()
    {
        // every step triggers a dice roll for combat
         if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) {
            num = Random.Range(0, 10);
            if (num < 3) {
                alert.text = "Enemy!";
                Pause();
                
                SceneManager.LoadScene("Battle");
            }
            else{
                alert.text = "";
            }
        }  
        if (Input.GetKeyDown(KeyCode.Q)) { // quit the program
            Application.Quit();
        } 
        if (Input.GetKeyDown(KeyCode.R)) {
            num = Random.Range(1, 5);
            if (player.hp+num >= player.max) {
                player.hp = player.max;
            }
            else{
                player.hp+=num;
            }

            stats.text = "HP: " + player.hp + "/" + player.max + "\nGold: " + player.gold; // update stats

            // check for enemy
            num = Random.Range(0, 10);
            if (num < 3) {
                alert.text = "Enemy!";
                SceneManager.LoadScene("Battle");
            }
            else{
                alert.text = "";
            }
        }
    }

    void Pause() {
        StartCoroutine(PauseRoutine());
        IEnumerator PauseRoutine(){
            int n = 0;
            if (n == 0){
                yield return new WaitForSeconds(1);
                n++;
            }
            
        }
        
    }
}
