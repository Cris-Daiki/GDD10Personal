using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;


public class colision : MonoBehaviour
{
    bool isEKeyPressed = false;
    private bool isDialogShowing;

    private bool disableDialog;
    bool sonIguales1;
    List<string> randomNames; // Declarar la variable randomNames como campo de la clase
    GameObject objetoSharedList;
    SharedList sharedList;
    public GameObject ObjetoDesactivar;
    public GameObject PressE;
    private Button BotonObjetoDesactivar;
    private GameObject Torch1;
    private GameObject Torch2;
    private GameObject Torch3;
    public ElevatorAnimation Elevator;

    // Start is called before the first frame update
    void Start()
    {
        BotonObjetoDesactivar = ObjetoDesactivar.GetComponentInChildren<Button>();
        BotonObjetoDesactivar.onClick.AddListener(OnSalirClick);
        disableDialog = false;
        isDialogShowing = false;
        Torch1 = GameObject.Find("PuzzleTorch");
        Torch2 = GameObject.Find("PuzzleTorch (1)");
        Torch3 = GameObject.Find("PuzzleTorch (2)");
        objetoSharedList = GameObject.Find("ControladorListas");
        sharedList = objetoSharedList.GetComponent<SharedList>();
        ShuffleNames(); // Llamar al método ShuffleNames() en el Start() para barajar los nombres
        
    }

    void ShuffleNames()
    {
        string[] names = { "PuzzleTorch", "PuzzleTorch (1)", "PuzzleTorch (2)" };
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
        Debug.Log("ESTA ES LA LISTA: ");
        foreach (string name in randomNames)
        {
            Debug.Log(name);
        }
        Debug.Log( transform.GetChild(0));
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
            // SceneManager.LoadScene("nivel 2");
            Elevator.isActive = true;
        }
        else if (randomNames.Count == sharedList.miListaJugador.Count)
        {
            print("mal");
            Torch1.transform.GetChild(0).gameObject.SetActive(false);
            Torch1.transform.GetChild(1).gameObject.SetActive(false);
            Torch2.transform.GetChild(0).gameObject.SetActive(false);
            Torch2.transform.GetChild(1).gameObject.SetActive(false);
            Torch3.transform.GetChild(0).gameObject.SetActive(false);
            Torch3.transform.GetChild(1).gameObject.SetActive(false);

            sharedList.miListaJugador.Clear();
        }
    }

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
            CancelInvoke("onEkeyPress");
            Invoke("onEkeyPress", .5f);
        }
    }
    public void EntrarMensaje()
    {
        if (!isDialogShowing && ! disableDialog)
        {
            ObjetoDesactivar.SetActive(true);
            isDialogShowing = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PressE.SetActive(false);
    }

    private void OnSalirClick()
    {
        isDialogShowing = false;
        ObjetoDesactivar.SetActive(false);
        disableDialog = true;
    }

    private void onEkeyPress() {
        if (transform.GetChild(0).gameObject.activeSelf)
        {
            string objeto = gameObject.name; // Obtener el nombre del objeto actual
            if (sharedList.miListaJugador.Contains(objeto))
            {
                // print("Eliminando objeto: " + objeto);
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
                // print("Agregando objeto: " + objeto);
                sharedList.miListaJugador.Add(objeto);
            }
        }
    }
}