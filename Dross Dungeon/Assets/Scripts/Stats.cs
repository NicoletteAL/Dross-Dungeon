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
        stats.text = "HP: " + player.hp + "/" + player.max + "\nGold: " + player.gold;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
