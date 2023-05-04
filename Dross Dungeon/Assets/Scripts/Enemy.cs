using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    private static Enemy _instance;

    public static Enemy Instance { get { return _instance; } }

    public int hp = 10;
    public int max = 10;
    public GameObject go;
    SpriteRenderer sp;
    public int gold = 15;
    public int low = 0, high = 3;

    // potential sprites
    public Sprite[] spArr;
    public string enemyName;
    public static bool isMini = false;


    // Start is called before the first frame update
    void Start()
    {
        hp = max;
        sp = go.GetComponent<SpriteRenderer>();
        if (isMini) {
            
            switch(GameManager.count) {
                case 0:
                    enemyName = "Dredge, Child Fatberg";
                    hp = 25;
                    max = 25;
                    low = 1;
                    high = 4;
                    sp.sprite = spArr[2];
                    break;
                case 1:
                    enemyName = "Filth, Child Fatberg";
                    hp = 35;
                    max = 35;
                    low = 3;
                    high = 5;
                    sp.sprite = spArr[3];
                    break;
                case 2:
                enemyName = "Dross, Mother of All Fatbergs";
                    hp = 50;
                    max = 25;
                    low = 5;
                    high = 8;
                    break;
            }
        }
        else {
            int num = Random.Range(0,2);
            hp = 10;
            max = 10;
            low = 0;
            high = 3;
            switch(num) {
            case 0:
                sp.sprite = spArr[0];
                enemyName = "Rat, The Ferocious Nugget of the Sewers:";
                break;
            case 1:
                sp.sprite = spArr[1];
                enemyName = "Skull, A Literal Flying Skull:";
                break;
        }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake(){
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
            
        }
    }
}
