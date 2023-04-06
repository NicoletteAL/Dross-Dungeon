using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stats : MonoBehaviour
{
    public TextMeshProUGUI stats;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        stats.text = "HP: " + Player.hp + "/" + Player.max + "\nGold: " + Player.gold;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
