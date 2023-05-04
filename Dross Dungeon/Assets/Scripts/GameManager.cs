using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    public static int count = 0;
    //public static int count = 0;
    public GameObject boss;
    public Sprite[] spArr;
    SpriteRenderer sp;

    //Enemy e = Enemy.Instance;


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
                transform.position = new Vector3(14.5f, -8.5f, -8.0f);
                break;
            case 1:
                sp.sprite = spArr[1];
                transform.position = new Vector3(-12.5f, 15.5f, -8.0f);
                break;
            case 2:
                sp.sprite = spArr[2];
                transform.position = new Vector3(20.5f, 1f, -8.0f);
                break;
            default:
                count = 0;
                GetComponent<AudioSource>().Stop();
                SceneManager.LoadScene("Win");
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

    private void OnTriggerEnter2D(Collider2D other) { // player bumps into the boss
    //e.setIsMini(false);
    Enemy.isMini = true;
    SceneManager.LoadScene("Battle");
    }
}
