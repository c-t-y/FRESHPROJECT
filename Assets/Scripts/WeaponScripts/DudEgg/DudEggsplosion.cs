using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudEggsplosion : MonoBehaviour
{
    public GameObject damageIndication;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeathDelay());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
          
            Instantiate(damageIndication, transform.position, Quaternion.identity);
            //Instantiate(strikeParticles, transform.position, Quaternion.identity);
            other.gameObject.GetComponent<EnemyController>().HitXL();
        }
        if (other.CompareTag("Object"))
        {
            other.gameObject.GetComponent<ObjectController>().Hit();
            //Instantiate(strikeParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }
    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }

}
