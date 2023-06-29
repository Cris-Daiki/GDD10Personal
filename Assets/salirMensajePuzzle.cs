using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salirMensajePuzzle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int contador =1;
    public GameObject ObjetoDesactivar;
    public void Salir(){
        if(contador == 1){
            ObjetoDesactivar.SetActive(false);
        }
        contador+=1;


    }
}
