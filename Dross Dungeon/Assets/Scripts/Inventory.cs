using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //Item[] items;
    List<Item> items;
    public int maxStorage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake() {
        DontDestroyOnLoad(gameObject);
    }
    void AddItem(Item item) {
        Item exist;
        if (items.Contains(item)) {
            exist = items.Find(i => i.id == item.id);
            exist.amount++;
        }
        else {
            items.Add(item);
        }
    }
}
