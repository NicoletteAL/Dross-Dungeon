using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    static int[,] map = {{1,1,1}, // should be 16 rows long
                    {1,0,1},
                    {1,0,1},
                    {1,0,1},
                    {1,0,1},
                    {1,0,1},
                    {1,9,1},
                    {1,0,1},
                    {1,0,1},
                    {1,0,1},
                    {1,0,1},
                    {1,0,1},
                    {1,0,1},
                    {1,0,1},
                    {1,0,1},
                    {1,1,1}};
    static int pr = 6, pc = 1; // player's position
    //int mapDirection=1; // 1 = up, 2 = down, 3 = left, 4 = right
    

    [Header("Outside Objects")]
    public GameObject[] go; // contains the view
    //public GameObject go2;
    // 0 = ceiling, 1 = leftwc, 2 = rightwc, 3 = wall, 4 = back, 5 = floor, 6 = leftwf, 7 = rightwf
    public Sprite[] spriteArray; // contains the potential sprites to show
    SpriteRenderer sp;

    char c;

    // Start is called before the first frame update
    void Start()
    {
        renderView();
    }

    // Update is called once per frame
    void Update()
    {
        c = '@';
        // check if a key is pressed
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            c = 'u';
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            c = 'd';
        }
        // if moving left or right, turn the array
        Move();
    }

    // coroutine to stimulate grid walking; force a wait for movement
    void Move () {

        int tr = pr, tc = pc;

        // check what movement was done
        switch(c) {
            case 'u':
                if (map[pr-1, pc] == 0 || pr > 1) {
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
        for(n = 1; n < 5; ++n) {
            //Debug.Log("n = " + n);
            switch(n) { // go through the rows
                case 1: // r - 1
                //Debug.Log("meow");
                    if (map[pr - n, 0] == 1) { // left wall
                        sp = go[0].GetComponent<SpriteRenderer>();
                        sp.sprite = spriteArray[1];
                        RenderSprites(1, 6, 3);
                        sp = go[6].GetComponent<SpriteRenderer>();
                        sp.sprite = spriteArray[6];
                    }
                    if (map[pr - n, 1] == 0) { // floor
                        RenderSprites(7, 12, 5);
                        RenderSprites(19, 24, 0); // ceiling
                    }
                    else { // cover large portion of screen
                            RenderSprites(0, 49, 4);
                            return;
                    }
                    if (map[pr - n, 2] == 1) { //right wall
                        sp = go[12].GetComponent<SpriteRenderer>();
                        sp.sprite = spriteArray[7];
                        RenderSprites(13, 18, 3);
                        sp = go[18].GetComponent<SpriteRenderer>();
                        sp.sprite = spriteArray[2];
                    }
                    
                    break;
                case 2:
                //Debug.Log("meow2");
                    if (map[pr - n, 0] == 1) { // left wall
                        sp = go[24].GetComponent<SpriteRenderer>();
                        sp.sprite = spriteArray[1];
                        RenderSprites(25, 28, 3);
                        sp = go[28].GetComponent<SpriteRenderer>();
                        sp.sprite = spriteArray[6];
                    }
                    if (map[pr - n, 1] == 0) { // floor
                        RenderSprites(29, 32, 5);
                        RenderSprites(37, 40, 0); // ceiling
                    }
                    else { // cover large portion of screen
                            RenderSprites(24, 49, 4);
                            return;
                    }
                    if (map[pr - n, 2] == 1) { //right wall
                        sp = go[32].GetComponent<SpriteRenderer>();
                        sp.sprite = spriteArray[7];
                        RenderSprites(33, 36, 3);
                        sp = go[36].GetComponent<SpriteRenderer>();
                        sp.sprite = spriteArray[2];
                    }
                    
                    break;
                case 3:
                //Debug.Log("meow3");
                    if (map[pr - n, 0] == 1) { // left wall
                        sp = go[40].GetComponent<SpriteRenderer>();
                        sp.sprite = spriteArray[1];
                        RenderSprites(41, 42, 3);
                        sp = go[42].GetComponent<SpriteRenderer>();
                        sp.sprite = spriteArray[6];
                    }
                    if (map[pr - n, 1] == 0) { // floor
                        RenderSprites(43, 44, 5);
                        RenderSprites(47, 48, 0); // ceiling
                    }
                    else { // cover large portion of screen
                        RenderSprites(40, 49, 4);
                        return;
                    }
                    if (map[pr - n, 2] == 1) { //right wall
                        sp = go[44].GetComponent<SpriteRenderer>();
                        sp.sprite = spriteArray[7];
                        RenderSprites(45, 47, 3);
                        sp = go[46].GetComponent<SpriteRenderer>();
                        sp.sprite = spriteArray[2];
                    }
                    
                    break;
                case 4:
                //Debug.Log("meow4");
                    if (map[pr - n, 1] == 1) {
                        sp = go[48].GetComponent<SpriteRenderer>();
                        sp.sprite = spriteArray[4];
                    }
                    else{
                        sp = go[48].GetComponent<SpriteRenderer>();
                        sp.sprite = spriteArray[0];
                    }
                    break;
            }

            if (map[pr - n, 1] == 1 && n != 4)  {
                //Debug.Log("Stopping at " + n);
                break;
            }

        }

    }

    void RenderSprites(int start, int limit, int type) {
        int i;
        for(i = start; i < limit; ++i) {
            sp = go[i].GetComponent<SpriteRenderer>();
            sp.sprite = spriteArray[type];
            //Debug.Log(go[i].name);
        }
        //Debug.Log(i);
    }

    void Turn() {

    }
}
