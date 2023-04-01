using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 3f;
    public float forceMultiplier = 10;

    //int x=0, y=0;

    [Header("Outside Objects")]
    //public GameObject myBoxGamePrefab;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
         Move();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // coroutine to stimulate grid walking; force a wait for movement
    void Move () {
        StartCoroutine(MoveRoutine());
    
        IEnumerator MoveRoutine(){
            while(true){ //goes forever
                rb2d.MovePosition(transform.position + (new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * Time.fixedDeltaTime) * speed);
                
                // scan surroundings to determine tileset to use

                yield return new WaitForSeconds(0.18f);
            }

        }

        

    }
}
