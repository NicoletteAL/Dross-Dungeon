using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Combat : MonoBehaviour
{
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

            // play hit sound
            GetComponent<AudioSource>().pitch = Random.Range(.7f,1.3f);
            GetComponent<AudioSource>().Play();

            e.hp-=num;
            if(e.hp <= 0) {
                alert.text = "You won!";
                e.GetComponent<AudioSource>().Play();
                Player.gold+=e.gold;
                Player.low +=2;
                Player.high += 2;
                if (e.getMini()) {
                    Player.max += 10;
                    GameManager.count++;
                }
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
                alert.text += "\nThe enemy did " + num + " damage";
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
                        alert.text += "\nThe enemy did " + num + " damage";
                    }
                    break;
            }
            textE.text = "HP: " + e.hp + "/" + e.max;
            textP.text = "HP: " + Player.hp + "/" + Player.max;
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            alert.text = "You gave up. The enemy left you go, taking some money if you have any";
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
        // reset the enemy
        e.hp = e.max;
        if (e.getMini()) {
            e.setIsMini(false);
        }
        SceneManager.LoadScene("Overworld");
    }

    void Lose() {
        // reset the player
        Player.max = Player.hp = 20;
        Player.lasPos = new Vector3(0f, 0f, -4.0f);
        Player.low = 0;
        Player.high = 4;
        Player.gold = 0;

        // reset the bosses
        GameManager.count = 0;
        GameManager g = GameManager.Instance;
        g.GetComponent<AudioSource>().Stop();

        SceneManager.LoadScene("Lose");
    }

}
