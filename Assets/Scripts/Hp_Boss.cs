using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp_Boss : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Image hpbar, redbar;
    [SerializeField] MovimientoEnemigo Boss;
    float maxhp, current_hp;
    bool Boss_dead = false;
    private void Start()
    {
        maxhp = Boss.hp;
        current_hp = Boss.hp;
    }
    void Update()
    {
        if(Boss!= null)
        {
            if (Boss.hp != current_hp)
            {
                current_hp = Boss.hp;
                float hppercentage = ((current_hp * 100) / maxhp) / 100.0f;
                hpbar.fillAmount = hppercentage;
                StopAllCoroutines();
                StartCoroutine(UpdateHealth(hppercentage));
            }
        }
        else if(!Boss_dead)
        {
            Boss_dead= true;
            hpbar.fillAmount = 0f;
            StopAllCoroutines();
            StartCoroutine(UpdateHealth(0f));
        }
    }
    IEnumerator UpdateHealth(float target)
    {
        yield return new WaitForSeconds(0.5f);
        while (redbar.fillAmount > target)
        {
            redbar.fillAmount -= 0.01f;
            yield return new WaitForSeconds(0.02f);
        }
        if (redbar.fillAmount < target)
        {
            redbar.fillAmount = target;
        }
        if(target == 0f)
        {
            gameObject.SetActive(false);
        }
    }
}
