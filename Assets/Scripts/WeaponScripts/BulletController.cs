using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//testing push
public class BulletController : MonoBehaviour
{

    public float lifeTime = 3f;
    public GameObject player;
    public GameObject damageIndication;
    public GameObject strikeParticles;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(Explode());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Explode()
    {
        yield return new WaitForSeconds(lifeTime);
        GetComponent<Collider2D>().enabled = true;
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

