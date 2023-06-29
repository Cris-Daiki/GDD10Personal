using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;


public class colision : MonoBehaviour
{
    bool isEKeyPressed = false;
    internal static int contador;
    bool sonIguales1;
    List<string> randomNames; // Declarar la variable randomNames como campo de la clase
    
    GameObject objetoSharedList;
    SharedList sharedList;

    // Start is called before the first frame update
    void Start()
    {
        contador = 1;
        objetoSharedList = GameObject.Find("ControladorListas");
        sharedList = objetoSharedList.GetComponent<SharedList>();
        ShuffleNames(); // Llamar al método ShuffleNames() en el Start() para barajar los nombres
        
    }

    void ShuffleNames()
    {
        string[] names = { "Torch", "Torch (1)", "Torch (2)" };
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
            Debug.Log("ESTA ES LA LISTA: "+ name);
        }
    }

    void Update()
    {
        foreach (string name in sharedList.miListaJugador)
        {
            Debug.Log("ListaJUGADOR: " + name);
        }

        bool sonIguales = true;
        if (randomNames.Count == sharedList.miListaJugador.Count)
        {
            for (int i = 0; i < randomNames.Count; i++)
            {
                if (randomNames[i] != sharedList.miListaJugador[i])
                {
                    sonIguales = false;
                    break;
                }
            }
        }
        else
        {
            sonIguales = false;
        }

        if (sonIguales)
        {
            print("CONGRATULATION");
            SceneManager.LoadScene("nivel 2");

        }

        // Verificar si se presiona o suelta la tecla "E"
        if (Input.GetKeyDown(KeyCode.E))
        {
            isEKeyPressed = true;
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            isEKeyPressed = false;
        }
    }

    public GameObject ObjetoDesactivar;
    public GameObject PressE;
    private void OnTriggerEnter(Collider other){ 
        if(other.CompareTag("Player")){
            PressE.SetActive(true);
            EntrarMensaje();
        }
        

    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (transform.GetChild(0).gameObject.activeSelf)
            {
                string objeto = gameObject.name; // Obtener el nombre del objeto actual
                if (sharedList.miListaJugador.Contains(objeto))
                {
                    print("Eliminando objeto: " + objeto);
                    sharedList.miListaJugador.Remove(objeto);

                    transform.GetChild(0).gameObject.SetActive(false);
                    transform.GetChild(1).gameObject.SetActive(false);
                }
            }
            else
            {
                string objeto = gameObject.name; // Obtener el nombre del objeto actual
                if (!sharedList.miListaJugador.Contains(objeto))
                {
                    transform.GetChild(0).gameObject.SetActive(true);
                    transform.GetChild(1).gameObject.SetActive(true);
                    print("Agregando objeto: " + objeto);
                    sharedList.miListaJugador.Add(objeto);
                }
            }
        }
    }
    public void EntrarMensaje()
    {
        if (contador == 1)
        {
            ObjetoDesactivar.SetActive(true);
            contador += 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PressE.SetActive(false);
    }
}