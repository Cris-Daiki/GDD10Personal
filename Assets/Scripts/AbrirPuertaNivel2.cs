using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPuertaNivel2 : MonoBehaviour
{
    public Animator animDor1,animDor2;
    public GameObject PressE;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(){
        PressE.SetActive(true);
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            
            print("Presion de tecla");
            PlayAnimationOnce();

        
        }
    }
    private void OnTriggerExit(){
        PressE.SetActive(false);
    }
    private void PlayAnimationOnce()
    {
        // Desactivar cualquier transición automática
        animDor1.Update(0f);
        animDor2.Update(0f);

        // Activar la animación deseada
        animDor1.SetTrigger("Collider");
        animDor2.SetTrigger("Collider");
    }
}
