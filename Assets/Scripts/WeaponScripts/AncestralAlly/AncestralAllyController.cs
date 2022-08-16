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
    private Vector2 newTargetPosition;
 
    private int randX;
    private int randY;
    private int randWait;
    public bool facingLeft = false;
    private float oldPosition = 0f;


    void Start()
    {
        bloodParticlePool = GameObject.FindGameObjectWithTag("BloodParticlePool").GetComponent<Pooler>();
   
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        //transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        oldPosition = transform.position.x;
        StartCoroutine(UpdateTarget());
        
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, newTargetPosition, speed * Time.deltaTime);
        if(transform.position.x > oldPosition)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (transform.position.x < oldPosition)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        oldPosition = transform.position.x;


    }



    private IEnumerator UpdateTarget()
    {
        while (true)
        {
            randX = Random.Range(-8, 8);
            randY = Random.Range(-8, 8);
            randWait = Random.Range(3, 4);
            newTargetPosition = new Vector3(player.transform.position.x + randX, player.transform.position.y + randY, 0);
            yield return new WaitForSeconds(randWait);
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
