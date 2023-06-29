using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Proyectile bullet_properties;
    [SerializeField] GameObject Explosion;
    float b_dmg, b_vel, b_reach, exp_reach = 5f,
        closedmg=15f,middmg=10f,fardmg = 5f;
    bool Is_Expl = true;
    Proyectile.BulletEffect[] b_effects;
    Vector3 initial_pos;
    Movimiento player;

    private void Start()
    {
        //b_dmg = bullet_properties.bullet_dmg;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Movimiento>();
        b_dmg = player.dmg;
        b_vel = bullet_properties.bullet_velocity;
        b_effects = bullet_properties.bullet_effects;
        b_reach = bullet_properties.bullet_reach;
        initial_pos = transform.position;
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, initial_pos) >= b_reach)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision hit)
    {
        print("Object hit = " + hit.gameObject);
        if (hit.transform.GetComponent<MovimientoEnemigo>() != null)
        {
            hit.transform.GetComponent<MovimientoEnemigo>().Change_HP(b_dmg);
        }
        if (Is_Expl)
        {
            Instantiate(Explosion, transform.position, transform.rotation);

            Collider[] colls = Physics.OverlapSphere(transform.position, exp_reach);
            foreach (Collider col in colls)
            {
                if (col.CompareTag("Enemy"))
                {
                    var distance = Vector3.Distance(col.transform.position, transform.position);
                    float damage = fardmg;
                    if (distance <= closedmg)
                    {
                        damage = closedmg;
                    }
                    else
                    if (distance <= middmg)
                    {
                        damage = middmg;
                    }
                    transform.GetComponent<MovimientoEnemigo>().Change_HP(damage);
                }
            }
        }
        Destroy(gameObject);
    }
}
