using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchlingChick : MonoBehaviour
{
    public GameObject player;
    public GameObject damageIndication;
    public Pooler damageIndicatorPool;

    public float chickSpeed;

    // Start is called before the first frame update
    void Start()
    {
        damageIndicatorPool = GameObject.FindGameObjectWithTag("DamageIndicatorPooler").GetComponent<Pooler>();
        player = GameObject.FindGameObjectWithTag("Player");
        chickSpeed = player.GetComponent<PlayerController>().playerSpeed * 1.75f;
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
            GameObject damageIndicator = damageIndicatorPool.GetObject();
            damageIndicator.transform.position = transform.position;
            damageIndicator.SetActive(true);
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
