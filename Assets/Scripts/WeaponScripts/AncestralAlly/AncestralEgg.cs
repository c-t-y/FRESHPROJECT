using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AncestralEgg : MonoBehaviour
{
    private float layTime;
    public GameObject compy;
    public GameObject raptor;
    public GameObject trex;

  
    void Start()
    {
        layTime = Time.time;
    }

    
    void Update()
    {
         if (Time.time - layTime >= 15f)
        {
            Instantiate(trex, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Enemy"))
        {
           if (Time.time - layTime <= 5f)
            {
                Destroy(gameObject);
            }
            else if (Time.time - layTime <= 10f)
            {
                Instantiate(compy, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
           else if (Time.time - layTime < 15f)
            {
                Instantiate(raptor, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else if (Time.time - layTime >= 15f)
            {
                Instantiate(trex, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

        }
    }
}
