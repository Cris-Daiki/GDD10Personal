using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_delete : MonoBehaviour
{
    float delay = 0.8f;
    void Awake()
    {
        if (!GetComponent<ParticleSystem>())
        {
            delay = 0.4f;
        }
        Invoke("Delete",delay);
    }
    void Delete()
    {
        Destroy(gameObject);
    }
}
