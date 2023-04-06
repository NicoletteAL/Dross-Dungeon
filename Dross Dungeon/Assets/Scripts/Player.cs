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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Awake(){
        //Player.instance = this;
        DontDestroyOnLoad(gameObject);
    }

}
