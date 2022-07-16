using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//testing push
public class BulletController : MonoBehaviour
{

    public float lifeTime;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeathDelay());
    }

    // Update is called once per frame
    void Update()
    {

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
            other.gameObject.GetComponent<EnemyController>().Hit();
            Destroy(gameObject);
        }
    }

}

