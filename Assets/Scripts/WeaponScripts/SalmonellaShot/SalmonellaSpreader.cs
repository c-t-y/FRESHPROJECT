using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalmonellaSpreader : MonoBehaviour
{
    public GameObject damageIndication;
    //public GameObject strikeParticles;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroySalmonella());
        StartCoroutine(ColliderOnOff());
    }

    IEnumerator DestroySalmonella()
    {
        yield return new WaitForSeconds(5.1f);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            //InvokeRepeating("SalmonellaSpread",1f, 1f);
            Instantiate(damageIndication, transform.position, Quaternion.identity);
            //Instantiate(strikeParticles, transform.position, Quaternion.identity);
            other.gameObject.GetComponent<EnemyController>().HitSmall();
           

        }
    }

    public IEnumerator ColliderOnOff()
    {
        yield return new WaitForSeconds(.75f);
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(.75f);
        GetComponent<Collider2D>().enabled = true;
        yield return new WaitForSeconds(.75f);
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(.75f);
        GetComponent<Collider2D>().enabled = true;
        yield return new WaitForSeconds(.75f);
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(.75f);
        GetComponent<Collider2D>().enabled = true;


    }
}
