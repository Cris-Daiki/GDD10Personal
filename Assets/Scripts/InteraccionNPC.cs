using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

using TMPro;

public class InteraccionNPC : MonoBehaviour
{
    public GameObject ScrollVew;
    public GameObject Hablando;
    public GameObject PanelTienda;
    public GameObject Dialogo;
    internal string frase1 = "Hola, con que puedo ayudarte hoy ?";
    public TMP_Text Texto;
    void Start()
    {
       
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //ScrollVew.SetActive(false);
            Hablando.SetActive(true);
            Dialogo.SetActive(true);
            StartCoroutine(Reloj());
        }
    }
    public StoreItems VariableA;
    private void OnTriggerStay(Collider other)
    {
        VariableA = FindObjectOfType<StoreItems>();
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E)){
                if(frase1 == "Hola, con que puedo ayudarte hoy ?"){
                    Dialogo.SetActive(false);
                    Hablando.SetActive(false);
                    PanelTienda.SetActive(true);
                }
                
            }
        }
    }
    public void BotonExit(){
        PanelTienda.SetActive(false);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines(); // Detener la corutina en caso de que esté en progreso
            Hablando.SetActive(false);
            ScrollVew.SetActive(true);
            Dialogo.SetActive(false);
            Texto.text = string.Empty;
        }
    }

    IEnumerator Reloj()
    {
        foreach (char caracter in frase1)
        {
            Texto.text = Texto.text + caracter;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
