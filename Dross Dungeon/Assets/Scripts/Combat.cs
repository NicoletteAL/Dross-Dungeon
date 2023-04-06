using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Combat : MonoBehaviour
{
    public Player p;
    public Enemy e;
    int num;
    public TextMeshProUGUI alert;
    public TextMeshProUGUI textE;
    public TextMeshProUGUI textP;
    // Start is called before the first frame update
    void Start()
    {
        textE.text = "HP: " + e.hp + "/" + e.max;
        textP.text = "HP: " + p.hp + "/" + p.max;
    }

    // Update is called once per frame
    void Update()
    {
        // check for input
        if (Input.GetKeyDown(KeyCode.A)) {
            num = Random.Range(p.low, p.high);
            e.hp-=num;
            if(e.hp <= 0) {
                alert.text = "You won!";
                p.gold+=e.gold;
                Win();
            }
            else{
                alert.text = "You did " + num + " damage";
            }
            num = Random.Range(e.low, e.high);
            p.hp-=num;
            if (p.hp<=0) {
                alert.text = "You lost...";
                Lose();
            }
            else {
                alert.text = "Rat did " + num + " damage";
            }
            textE.text = "HP: " + e.hp + "/" + e.max;
            textP.text = "HP: " + p.hp + "/" + p.max;
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            num = Random.Range(0, 10);
            switch(num) {
                case 1:
                    alert.text = "You managed to get away";
                    Win();
                    break;
                default:
                    alert.text = "You failed to get away. The Rat has a free attack!";
                    num = Random.Range(e.low, e.high) + 1;
                    p.hp-=num;
                    if (p.hp<=0) {
                        alert.text = "You lost...";
                        Lose();
                    }
                    else {
                        alert.text = "Rat did " + num + " damage";
                    }
                    break;
            }
            textE.text = "HP: " + e.hp + "/" + e.max;
            textP.text = "HP: " + p.hp + "/" + p.max;
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            alert.text = "You gave up. The Rat left you go, taking some money if you have any";
            p.gold-=Random.Range(5, 25);
            if (p.gold < 0) {
                //alert.text = "You have no money? The Rat beats you up!";
                p.gold = 0;
            }
            Win();
            textE.text = "HP: " + e.hp + "/" + e.max;
            textP.text = "HP: " + p.hp + "/" + p.max;
        }
    }

    void Win() {
        SceneManager.LoadScene("Map");
    }

    void Lose() {
        SceneManager.LoadScene("SampleScene");
    }

    /* void Pause() { Use if there is time left
        StartCoroutine(PauseRoutine());
        IEnumerator PauseRoutine(){
            int n = 0;
            if (n == 0){
                yield return new WaitForSeconds(1);
                n++;
            }
            
        }
        
    }*/
}