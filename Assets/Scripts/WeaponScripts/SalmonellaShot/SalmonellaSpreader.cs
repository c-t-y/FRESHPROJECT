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
            InvokeRepeating("SalmonellaSpread",1f, 1f);
            Instantiate(damageIndication, transform.position, Quaternion.identity);
            //Instantiate(strikeParticles, transform.position, Quaternion.identity);
        }
    }

    public void SalmonellaSpread()
    {
        gameObject.GetComponent<EnemyController>().Hit();
    }
}
