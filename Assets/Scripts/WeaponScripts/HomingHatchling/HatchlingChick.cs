using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchlingChick : MonoBehaviour
{
    public GameObject player;
    public GameObject damageIndication;
    public float chickSpeed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        chickSpeed = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, chickSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Enemy"))
        {
            Instantiate(damageIndication, transform.position, Quaternion.identity);
            //Instantiate(strikeParticles, transform.position, Quaternion.identity);
            other.gameObject.GetComponent<EnemyController>().Hit();

           
        }
        if (other.CompareTag("Player"))
        {
           
            //Instantiate(strikeParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }

    }
}
