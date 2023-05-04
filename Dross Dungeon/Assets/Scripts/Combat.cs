using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Combat : MonoBehaviour
{
    //public Player p;
    public Enemy e;
    int num;
    public TextMeshProUGUI alert;
    public TextMeshProUGUI textE;
    public TextMeshProUGUI textP;
    public TextMeshProUGUI enemyName;
    // Start is called before the first frame update
    void Start()
    {
        textE.text = "HP: " + e.hp + "/" + e.max;
        textP.text = "HP: " + Player.hp + "/" + Player.max;
        enemyName.text = e.enemyName;
    }

    // Update is called once per frame
    void Update()
    {
        // check for input
        if (Input.GetKeyDown(KeyCode.A)) {
            num = Random.Range(Player.low, Player.high);
            e.hp-=num;
            if(e.hp <= 0) {
                alert.text = "You won!";
                Player.gold+=e.gold;
                Player.low +=2;
                Player.high += 2;
                Win();
            }
            else{
                alert.text = "You did " + num + " damage";
            }
            num = Random.Range(e.low, e.high);
            Player.hp-=num;
            if (Player.hp<=0) {
                alert.text = "You lost...";
                Lose();
            }
            else {
                alert.text += "\nRat did " + num + " damage";
            }
            textE.text = "HP: " + e.hp + "/" + e.max;
            textP.text = "HP: " + Player.hp + "/" + Player.max;
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
                    Player.hp-=num;
                    if (Player.hp<=0) {
                        alert.text = "You lost...";
                        Lose();
                    }
                    else {
                        alert.text += "\nRat did " + num + " damage";
                    }
                    break;
            }
            textE.text = "HP: " + e.hp + "/" + e.max;
            textP.text = "HP: " + Player.hp + "/" + Player.max;
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            alert.text = "You gave up. The Rat left you go, taking some money if you have any";
            Player.gold-=Random.Range(5, 25);
            if (Player.gold < 0) {
                //alert.text = "You have no money? The Rat beats you up!";
                Player.gold = 0;
            }
            Win();
            textE.text = "HP: " + e.hp + "/" + e.max;
            textP.text = "HP: " + Player.hp + "/" + Player.max;
        }
    }

    void Win() {
        SceneManager.LoadScene("Overworld");
    }

    void Lose() {
        SceneManager.LoadScene("SampleScene");
    }

}
