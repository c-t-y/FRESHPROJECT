using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggMineObject : MonoBehaviour
{

    public float lifeTime = 3f;
    public GameObject player;
    public GameObject damageIndication;
  
    

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Collider2D>().enabled = false;
        InvokeRepeating("Explode", lifeTime, .1f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Explode()
    {
        GetComponent<Collider2D>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Enemy"))
        {
            Instantiate(damageIndication, transform.position, Quaternion.identity);
           
            other.gameObject.GetComponent<EnemyController>().Hit();

            Destroy(gameObject);
        }
        if (other.CompareTag("Object"))
        {
            other.gameObject.GetComponent<ObjectController>().Hit();
          
            Destroy(gameObject);

        }

    }


}
