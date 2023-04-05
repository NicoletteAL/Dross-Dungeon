using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    //public float speed = 3f;
    //public float forceMultiplier = 10;

    int[,] map = {{1,1,1,1,1}, 
                    {1,0,1,0,1},
                    {1,0,1,0,1},
                    {1,0,1,0,1},
                    {1,9,1,0,1},
                    {1,1,1,1,1}};
    int pr = 4, pc = 1; // player's position
    int mapDirection=1; // 1 = up, 2 = down, 3 = left, 4 = right
    

    [Header("Outside Objects")]
    public GameObject[] go; // contains the view
    public GameObject go2;
    // 0 = ceiling, 1 = leftwc, 2 = rightwc, 3 = wall, 4 = back, 5 = floor, 6 = leftwf, 7 = rightwf
    public Sprite[] spriteArray; // contains the potential sprites to show
    SpriteRenderer sp;

    char c;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        c = '@';
        // check if a key is pressed
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            c = 'u';
            Debug.Log("Moving");
            sp = go2.GetComponent<SpriteRenderer>();
            sp.sprite = spriteArray[3];
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            c = 'd';
            Debug.Log("Moving");
            sp = go2.GetComponent<SpriteRenderer>();
            sp.sprite = spriteArray[0];
        }
        // if moving left or right, turn the array
        Move();
    }

    // coroutine to stimulate grid walking; force a wait for movement
    void Move () {

        int tr = pr, tc = pc;
        //int i, j;

        // check what movement was done
        switch(c) {
            case 'u':
                if (map[pr-1, pc] == 0 || pr > 1) {
                    //tr = pr; tc = pc;
                    map[pr-1, pc] = 9;
                    map[pr, pc] = 0;
                    pr-=1;
                }
                break;
            case 'd':
            if (map[pr+1, pc] == 0 || pr < 4) {
                    map[pr+1, pc] = 9;
                    map[pr, pc] = 0;
                    pr+=1;
                    Debug.Log(pr);
                }
                break;
            default:
                return;
                //break;
        }

        // view the array
        renderView();
        

    }

    void renderView() {
        int n;
        int i;
        int limit = 6;
        int start = 1;
        for(n = 1; n < 5; ++n) {
            Debug.Log("n = " + n);
            if (map[pr - n, 1] == 1)  {
                break;
            }
            switch(n) { // go through the rows
                case 1:
                    if (map[pr - n, 0] == 1) { // left wall
                        sp = go[0].GetComponent<SpriteRenderer>();
                        sp.sprite = spriteArray[1];
                        RenderSprites(1, 6, 3);
                        sp = go[6].GetComponent<SpriteRenderer>();
                        sp.sprite = spriteArray[6];
                    }
                    start = 7;
                    limit = 12;
                    if (map[pr - n, 1] == 0) { // floor
                        for(i = start; i < limit; ++i) {
                            sp = go[i].GetComponent<SpriteRenderer>();
                            sp.sprite = spriteArray[5];
                        }
                    }
                    else { // cover large portion if screen
                        for(i = 0; i < 48; ++i) {
                            sp = go[i].GetComponent<SpriteRenderer>();
                            sp.sprite = spriteArray[4];
                        }
                        Debug.Log("up close");
                    }
                    sp = go[12].GetComponent<SpriteRenderer>();
                    sp.sprite = spriteArray[7];
                    if (map[pr - n, 2] == 1) {

                    }
                    break;
                case 4:
                    if (map[pr - n, 0] == 1) {
                        sp = go[48].GetComponent<SpriteRenderer>();
                        sp.sprite = spriteArray[4];
                    }
                    else{
                        sp = go[48].GetComponent<SpriteRenderer>();
                        sp.sprite = spriteArray[0];
                    }
                    break;
            }

        }
string s="";
int k,h;
        for (k = 0; k < 6; ++k) {
            for(h = 0; h<5; ++h) {
//Debug.Log(k + " ");
s+=map[k,h]+" ";
            }
            
            s+="\n";
            //Debug.Log(" ");
        }

        Debug.Log(s);
    }

    void RenderSprites(int start, int limit, int type) {
        int i;
        for(i = start; i < limit; ++i) {
            sp = go[i].GetComponent<SpriteRenderer>();
            sp.sprite = spriteArray[type];
        }
    }

    void Turn() {
        
    }
}
