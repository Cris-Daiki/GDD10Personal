using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreItems : MonoBehaviour
{
    Movimiento a;
    public Item itemToADD;
    public int amountToadd;
    public string itemName;
    public int itemSellPrice;
    public int ItembuyPrice;
    TextMeshProUGUI buyPriceText;
    private void Start(){

        itemName = itemToADD.name;
        a = GameObject.FindGameObjectWithTag("Player").GetComponent<Movimiento>();
        buyPriceText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        buyPriceText.text = "$ "+ItembuyPrice.ToString();
    }
    public void AddToInventory1()
    {
        a.AddToInventoryToStore(itemToADD);

    }
    public void BuyItem(){
        //if(ItembuyPrice <= BankAccount.instance.bank){
            // BankAccount.instance.bank -=ItembuyPrice;
             AddToInventory1();
        //}
    }
}
