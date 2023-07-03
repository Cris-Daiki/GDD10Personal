using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPuertaNivel2 : MonoBehaviour
{
    public Animator animDor1,animDor2;
    public GameObject PressE;

    private bool isActive = true;

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player") && isActive){
            PressE.SetActive(true);
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E) && isActive)
        {
            CancelInvoke("onEkeyPress");
            Invoke("onEkeyPress", .5f);
        }
    }
    private void OnTriggerExit(){
        PressE.SetActive(false);
    }
    private void PlayAnimationOnce()
    {
        isActive = false;
        PressE.SetActive(false);
        // Desactivar cualquier transición automática
        animDor1.Update(0f);
        animDor2.Update(0f);

        // Activar la animación deseada
        animDor1.SetTrigger("Collider");
        animDor2.SetTrigger("Collider");
    }

    private void onEkeyPress() {
        print("Presion de tecla");
        PlayAnimationOnce();
    }
}
