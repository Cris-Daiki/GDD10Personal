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
    string frase1 = "Hola, con que puedo ayudarte hoy ?";
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
            ScrollVew.SetActive(false);
            Hablando.SetActive(true);
            Dialogo.SetActive(true);
            StartCoroutine(Reloj());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E)){
                Dialogo.SetActive(false);
                Hablando.SetActive(false);
                PanelTienda.SetActive(true);
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
            Texto.text = string.Empty;
        }
    }

    IEnumerator Reloj()
    {
        foreach (char caracter in frase1)
        {
            Texto.text = Texto.text + caracter;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
