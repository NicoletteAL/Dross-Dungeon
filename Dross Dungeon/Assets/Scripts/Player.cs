using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int hp = 10;
    public int max = 10;
    public int low = 0, high = 4;
    public int gold = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Awake(){
        DontDestroyOnLoad(gameObject);
    }

}