using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public static Player instance;
    public static int hp = 20;
    public static int max = 20;
    public static int low = 0, high = 4;
    public static int gold = 0;

    private static Player _instance;

    public static Player Instance { get { return _instance; } }

    public static Vector3 lasPos;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = lasPos;
    }

    // Update is called once per frame
    void Update()
    {
        lasPos = transform.position;
    }

    void Awake(){
        //Player.instance = this;
        //DontDestroyOnLoad(gameObject);
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
            
        }
    }

}
