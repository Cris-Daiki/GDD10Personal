using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Play_Exit : MonoBehaviour
{
    public void Inicio(){
        SceneManager.LoadScene("level1 km edittion");
    }
    public void Exit(){
        Application.Quit();
    }
}

