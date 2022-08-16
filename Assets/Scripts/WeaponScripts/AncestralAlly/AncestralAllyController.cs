using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AncestralAllyController : MonoBehaviour
{

    GameObject player;
    SpriteRenderer spriteRenderer;
    public Pooler bloodParticlePool;

    public float speed;
    public float currentHealth;
    public float allyDamageTaken;


    void Start()
    {
        bloodParticlePool = GameObject.FindGameObjectWithTag("BloodParticlePool").GetComponent<Pooler>();
   
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < .5f)
        {
            StartCoroutine(Patrol());
        }
    

    }

    private IEnumerator Patrol()
    {
        while (true)
        {
            transform.position = new Vector2(player.transform.position.x + 3f, player.transform.position.y + 3f);
            yield return new WaitForSeconds(5f);
            transform.position = new Vector2(player.transform.position.x + -3f, player.transform.position.y + 3f);
            yield return new WaitForSeconds(5f);
            transform.position = new Vector2(player.transform.position.x + -3f, player.transform.position.y + -3f);
            yield return new WaitForSeconds(5f);
            transform.position = new Vector2(player.transform.position.x + 3f, player.transform.position.y + -3f);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            StartCoroutine(FlashRed());
            currentHealth -= allyDamageTaken;
            StartCoroutine(DamageTakenCoolDown());
            if ((currentHealth <= 0))
            {
                Death();
            }
        }
    }

    public IEnumerator DamageTakenCoolDown()
    {
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(1f);
        GetComponent<Collider2D>().enabled = true;
    }

    public void Death()
    {
        //GameObject explosion = (GameObject)Instantiate(explosionRef);
        GameObject explosion = bloodParticlePool.GetObject();
        explosion.transform.position = new Vector3(transform.position.x, transform.position.y + .3f, transform.position.z);
        explosion.SetActive(true);

        Destroy(gameObject);
    }

    public IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }
}
