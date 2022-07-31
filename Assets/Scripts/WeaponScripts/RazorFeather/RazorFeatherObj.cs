using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RazorFeatherObj : MonoBehaviour
{
    
    public GameObject player;
    public GameObject damageIndication;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("DestroyRazor", 4f, 1f);
        gameObject.transform.parent = player.transform;

    }

    public void DestroyRazor()
    {
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Enemy"))
        {
            Instantiate(damageIndication, transform.position, Quaternion.identity);
            //Instantiate(strikeParticles, transform.position, Quaternion.identity);
            other.gameObject.GetComponent<EnemyController>().Hit();


        }
      

    }


}
