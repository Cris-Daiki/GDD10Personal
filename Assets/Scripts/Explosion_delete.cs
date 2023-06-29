using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_delete : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Delete",1.5f);
    }
    void Delete()
    {
        Destroy(gameObject);
    }
}
