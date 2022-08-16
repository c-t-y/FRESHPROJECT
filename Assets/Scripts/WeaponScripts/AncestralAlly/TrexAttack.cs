using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrexAttack : MonoBehaviour
{

    private bool coolDownAttack;
    public float coolDown;
    //public Pooler damageIndicatorPool;

    void Start()
    {
        coolDownAttack = false;
    }


    void Update()
    {
        if (coolDownAttack == false)
        {

            StartCoroutine(Attack());
        }


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {

            //GameObject damageIndicator = damageIndicatorPool.GetObject();
            //damageIndicator.transform.position = transform.position;
            //damageIndicator.SetActive(true);
            //Instantiate(strikeParticles, transform.position, Quaternion.identity);
            other.gameObject.GetComponent<EnemyController>().HitLarge();


        }
    }



    public IEnumerator Attack()
    {
        GetComponent<Collider2D>().enabled = true;
        yield return new WaitForSeconds(.5f);
        GetComponent<Collider2D>().enabled = false;
        coolDownAttack = true;
        yield return new WaitForSeconds(coolDown);
        coolDownAttack = false;

    }
}
