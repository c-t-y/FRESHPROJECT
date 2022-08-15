using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchlingBullet : MonoBehaviour
{
    public float lifeTime = 4f;
    public GameObject player;

    //public GameObject strikeParticles;
    public GameObject hatchChick;


    public void Start()
    {
        StartCoroutine(DeathDelay());
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
            transform.parent = other.transform;
            other.gameObject.GetComponent<EnemyController>().Hit();
            //Instantiate(strikeParticles, transform.position, Quaternion.identity);
            Instantiate(hatchChick, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }


    }



}
