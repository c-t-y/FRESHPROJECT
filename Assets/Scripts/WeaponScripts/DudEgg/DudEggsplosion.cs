using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudEggsplosion : MonoBehaviour
{
    public GameObject damageIndication;
    public Pooler damageIndicatorPool;


    // Start is called before the first frame update
    void Start()
    {
        damageIndicatorPool = GameObject.FindGameObjectWithTag("DamageIndicatorPooler").GetComponent<Pooler>();
        StartCoroutine(DeathDelay());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {

            GameObject damageIndicator = damageIndicatorPool.GetObject();
            damageIndicator.transform.position = transform.position;
            damageIndicator.SetActive(true);
            //Instantiate(strikeParticles, transform.position, Quaternion.identity);
            other.gameObject.GetComponent<EnemyController>().HitXL();
        }
        if (other.CompareTag("Object"))
        {
            other.gameObject.GetComponent<ObjectController>().Hit();
            //Instantiate(strikeParticles, transform.position, Quaternion.identity);


        }
    }
    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }

}
