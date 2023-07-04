using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Entity_Controller : MonoBehaviour
{
    [SerializeField] bool HasBosses = false;
    [SerializeField] int NextLvl;
    [SerializeField] GameObject EnemyHp = null;
    [SerializeField] GameObject Room_Prefab;
    [SerializeField] MovimientoEnemigo Boss = null;
    [SerializeField] TMPro.TextMeshProUGUI m_teleport;
    GameObject player;
    bool tp_started = false;

    private void Start()
    {
        FindPlayer();
        
    }
    public void killplayer()
    {
        player.GetComponent<Movimiento>().Die();
    }
    private void Update()
    {
        if(player == null)
        {
            LevelSwitch(NextLvl - 1);
        }
        else
        {
            if (HasBosses)
            {
                if (Boss != null)
                {
                    float distance = Vector3.Distance(player.transform.position, Boss.transform.position);
                    if (distance < 25f && !EnemyHp.activeSelf)
                    {
                        EnemyHp.SetActive(true);
                    }
                    else if (distance > 25f && EnemyHp.activeSelf)
                    {
                        EnemyHp.SetActive(false);
                    }
                }
                else if(!tp_started)
                {
                    tp_started = true;
                    StartCoroutine(CountDownTP(15, NextLvl));
                }
            }
        }
    }
    public void Set_playernull()
    {
        player = null;
    }
    void LevelSwitch(int level)
    {
        switch(level)
        {
            case 1:
                SceneManager.LoadScene("level1 km edittion");
                break;
            case 2:
                SceneManager.LoadScene("nivel 2");
                break;
            case 3:
                SceneManager.LoadScene("nivel 3");
                break;
            case 4:
                SceneManager.LoadScene("MundoAbierto");
                break;
        }

    }
    void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //Spawns = GameObject.FindGameObjectsWithTag("Spawner");
    }
    IEnumerator CountDownTP(int x, int lvl)
    {
        while(x!=0)
        {
            m_teleport.text = "Teleportandose al siguiente nivel en : "+x.ToString()+" segundos";
            x--;
            yield return new WaitForSeconds(1f);
        }
        LevelSwitch(lvl);
    }
}