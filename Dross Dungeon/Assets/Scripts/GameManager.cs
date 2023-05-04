using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    public static int count = 0;
    //public static int count = 0;
    public GameObject boss;
    public Sprite[] spArr;
    SpriteRenderer sp;


    // Start is called before the first frame update
    void Start()
    {
        CheckSprite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckSprite() {
        sp = boss.GetComponent<SpriteRenderer>();
        switch(count) {
            case 0:
                sp.sprite = spArr[0];
                boss.transform.position = new Vector3(14.5f, -8.5f, -8.0f);
                break;
        }
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
