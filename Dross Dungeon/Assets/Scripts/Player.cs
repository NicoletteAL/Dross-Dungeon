using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
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
        // check keys, then move in a grid
        /*if (Input.GetKeyDown(KeyCode.D)) { // right
            x=5;
             rb2d.MovePosition(transform.position + (new Vector3(x,y) * Time.fixedDeltaTime * speed));
        }
        if (Input.GetKeyDown("left")) { //  left
            x=-1;
        }
        if (Input.GetKeyDown("up")) { // up
            y=1;
        }
        if (Input.GetKeyDown("down")) {// down
            y=-1;
        }*/

        //rb2d.MovePosition(transform.position + (new Vector3(x,y) * Time.fixedDeltaTime));
        //x=y=0;
    }

    // coroutine to stimulate grid walking; force a wait for movement
    void Move () {
        StartCoroutine(MoveRoutine());
    
        IEnumerator MoveRoutine(){
            while(true){ //goes forever
                rb2d.MovePosition(transform.position + (new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * Time.fixedDeltaTime) * speed);
                
                // scan surroundings to determin tileset to use

                yield return new WaitForSeconds(0.1f);
            }

        }

        

    }
}
