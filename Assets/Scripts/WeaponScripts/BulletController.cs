using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//testing push
public class BulletController : MonoBehaviour
{

    public float lifeTime = 4f;
    public GameObject player;
    public GameObject damageIndication;
    public GameObject strikeParticles;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(DeathDelay());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Enemy"))
        {
            Instantiate(damageIndication, transform.position, Quaternion.identity);
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

