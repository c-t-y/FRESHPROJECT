using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudEggNosplosion : MonoBehaviour
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
            other.gameObject.GetComponent<EnemyController>().HitXS();


        }
    }
    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }

}
