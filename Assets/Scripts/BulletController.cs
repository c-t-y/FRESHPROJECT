using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//testing push
public class BulletController : MonoBehaviour
{

    public float lifeTime = 4f;
    public float bulletDamage = 2f;
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
        if(other.CompareTag("Object"))
        {
            other.gameObject.GetComponent<ObjectController>().Hit();
            Destroy(gameObject);

        }
    }

}

