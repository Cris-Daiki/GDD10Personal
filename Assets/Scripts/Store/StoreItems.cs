using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreItems : MonoBehaviour
{
    Movimiento a;
    public GameObject itemToADD;
    public int amountToadd;
    public string itemName;
    public int itemSellPrice;
    public int ItembuyPrice;
    
    private void Start(){

        itemName = itemToADD.name;
        a = GameObject.FindGameObjectWithTag("Player").GetComponent<Movimiento>();
    }
    public void AddToInventory(Item item)
    {
        a.AddToInventory(item);
        a.Update_Stats(item);
    }
}
