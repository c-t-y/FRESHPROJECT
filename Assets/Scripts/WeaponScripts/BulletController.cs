using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//testing push
public class BulletController : MonoBehaviour
{
    public float lifeTime = 4f;
    public GameObject player;
    public GameObject strikeParticles;
    private Pooler pool;
    public Pooler damageIndicatorPool;

    // Start is called before the first frame update
    void Start()
    {
        damageIndicatorPool = GameObject.FindGameObjectWithTag("DamageIndicatorPooler").GetComponent<Pooler>();
        pool = transform.parent.GetComponent<Pooler>();
        StartCoroutine(DeathDelay());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(lifeTime);
        pool.ReturnObject(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Enemy"))
        {
            //Instantiate(damageIndication, transform.position, Quaternion.identity);
            GameObject damageIndicator = damageIndicatorPool.GetObject();
            damageIndicator.transform.position = transform.position;
            damageIndicator.SetActive(true);


            Instantiate(strikeParticles, transform.position, Quaternion.identity);
            other.gameObject.GetComponent<EnemyController>().Hit();

            Destroy(gameObject);
        }
        if (other.CompareTag("Object"))
        {
            other.gameObject.GetComponent<ObjectController>().Hit();
            Instantiate(strikeParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }

    }


}


