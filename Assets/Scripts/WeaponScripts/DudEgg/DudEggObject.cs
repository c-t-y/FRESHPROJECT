using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudEggObject : MonoBehaviour
{
    public float lifeTime = 2f;
    public GameObject player;
    public int dudchance;
    public GameObject eggsplosion;
    public GameObject nosplosion;

    //public GameObject strikeParticles;
   


    public void Start()
    {
        StartCoroutine(DeathDelay());
    }


    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(lifeTime);
        dudchance = Random.Range(0, 101);
        if(dudchance <= 20)
        {
            Instantiate(eggsplosion, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(nosplosion, transform.position, Quaternion.identity);
        }
                

        Destroy(gameObject);
    }

}
