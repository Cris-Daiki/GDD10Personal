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
    public GameObject PanelTienda;
    public GameObject InteraccionMercader;
    InteraccionNPC InteraccionNueva;
    public static int contadorStore=0;
    public bool contadorRespaldo;
    private void Start(){
        
        contadorRespaldo=true;
        InteraccionNueva =InteraccionMercader.GetComponent<InteraccionNPC>();
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
        contadorStore +=1;
        if(contadorStore ==1){
            AddToInventory1();
            contadorStore +=1;
            PanelTienda.SetActive(false);
            contadorRespaldo= false;

        }else{
            InteraccionNueva.frase1 = "Lo siento Ya compraste en esta tienda";
        }

        //}
    }
}
