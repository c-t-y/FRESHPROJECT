using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RazorFeatherObj : MonoBehaviour
{

    public GameObject player;
    public Pooler damageIndicatorPool;


    // Start is called before the first frame update
    void Start()
    {
        damageIndicatorPool = GameObject.FindGameObjectWithTag("DamageIndicatorPooler").GetComponent<Pooler>();
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
            GameObject damageIndicator = damageIndicatorPool.GetObject();
            damageIndicator.transform.position = transform.position;
            damageIndicator.SetActive(true);
            //Instantiate(strikeParticles, transform.position, Quaternion.identity);
            other.gameObject.GetComponent<EnemyController>().Hit();


        }


    }


}
