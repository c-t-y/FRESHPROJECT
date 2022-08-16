using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaptorAttack : MonoBehaviour
{
    private bool coolDownAttack;
    public float coolDown;
    public Pooler damageIndicatorPool;

    void Start()
    {
        coolDownAttack = false;
    }


    void Update()
    {
        if (coolDownAttack == false)
        {
            GetComponent<Collider2D>().enabled = true;
            StartCoroutine(CoolDown());
        }
        else
        {
            GetComponent<Collider2D>().enabled = false;
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {

            GameObject damageIndicator = damageIndicatorPool.GetObject();
            damageIndicator.transform.position = transform.position;
            damageIndicator.SetActive(true);
            //Instantiate(strikeParticles, transform.position, Quaternion.identity);
            other.gameObject.GetComponent<EnemyController>().Hit();


        }
    }



    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(.1f);
        coolDownAttack = true;
        yield return new WaitForSeconds(coolDown);
        coolDownAttack = false;
    }
}

