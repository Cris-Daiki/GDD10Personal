using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class colision : MonoBehaviour
{
    internal static int contador;
    public List<string> miListaJugador;
    bool sonIguales1;
    List<string> randomNames; // Declarar la variable randomNames como campo de la clase

    // Start is called before the first frame update
    void Start()
    {
        contador = 1;
        ShuffleNames(); // Llamar al método ShuffleNames() en el Start() para barajar los nombres
    }

    void ShuffleNames()
    {
        string[] names = { "Torch (9)", "Torch (7)", "Torch (6)", "Torch (1)" };
        randomNames = new List<string>(names);

        // Barajar los nombres en randomNames de forma aleatoria
        System.Random rng = new System.Random();
        int n = randomNames.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            string value = randomNames[k];
            randomNames[k] = randomNames[n];
            randomNames[n] = value;
        }

        // Imprimir los nombres en orden aleatorio
        foreach (string name in randomNames)
        {
            Debug.Log(name);
        }
    }

    // Update is called once per frame

    void Update()
    {
        sonIguales1 = randomNames.SequenceEqual(miListaJugador);
        if (sonIguales1)
        {
            print("CONGRATULATION");
        }
    }

    internal string Objeto;

    public GameObject ObjetoDesactivar;
    public GameObject PressE;
    private void OnTriggerEnter(Collider other)
    {
        EntrarMensaje();
        PressE.SetActive(true);
        Objeto = transform.name;
        print(transform);
    }

    public void EntrarMensaje()
    {
        if (contador == 1)
        {
            ObjetoDesactivar.SetActive(true);
            contador += 1;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (transform.GetChild(0).gameObject.activeInHierarchy)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PressE.SetActive(false);
    }

    public void controlerPuzzeCharacter()
    {

    }
}
