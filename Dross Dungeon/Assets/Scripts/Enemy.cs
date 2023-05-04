using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public int hp = 10;
    public int max = 10;
    public GameObject go;
    SpriteRenderer sp;
    public int gold = 15;
    public int low = 0, high = 3;

    // potential sprites
    public Sprite[] spArr;
    public string enemyName;
    public bool isMini = false;


    // Start is called before the first frame update
    void Start()
    {
        if (isMini) {
            enemyName = "Child Fatburg";
        }
        else {
            int num = Random.Range(0,2);
            sp = go.GetComponent<SpriteRenderer>();
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

    void Die() {
        Destroy(gameObject);
    }
}
