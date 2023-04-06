using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 10;
    public GameObject go;
    SpriteRenderer sp;
    public int gold;
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
