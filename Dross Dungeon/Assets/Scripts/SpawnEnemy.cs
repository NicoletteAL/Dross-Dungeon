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
    //public Player player;
    // Start is called before the first frame update
    void Start()
    {
        stats.text = "HP: " + Player.hp + "/" + Player.max + "\nGold: " + Player.gold;
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
            if (Player.hp == Player.max) {
                alert.text = "You're already fully healed";
                Pause();
                alert.text = "";
            }
            else {
                num = Random.Range(1, 5);
                alert.text = "Healed " + num + " HP";
                if (Player.hp+num >= Player.max) {
                    Player.hp = Player.max;
                }
                else{
                    Player.hp+=num;
                }
                stats.text = "HP: " + Player.hp + "/" + Player.max + "\nGold: " + Player.gold; // update stats

                Pause();

                // check for enemy
                num = Random.Range(0, 10);
                if (num < 3) {
                    alert.text = "Enemy!";
                    Enemy.isMini = false;
                    SceneManager.LoadScene("Battle");
                }
                else{
                    alert.text = "";
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.O)) {
            SceneManager.LoadScene("Settings");
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
