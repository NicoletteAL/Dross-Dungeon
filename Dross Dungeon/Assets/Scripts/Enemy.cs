using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 10;
    public int max = 10;
    public GameObject go;
    SpriteRenderer sp;
    public int gold = 15;
    public int low = 0, high = 3;
    // Start is called before the first frame update
    void Start()
    {
        sp = go.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Die() {
        Destroy(gameObject);
    }
}
