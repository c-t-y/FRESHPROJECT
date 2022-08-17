using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonChicken : MonoBehaviour
{
    public GameObject player;
    public Pooler damageIndicatorPool;

    public float rotateSpeed;


    // Start is called before the first frame update
    void Start()
    {
        damageIndicatorPool = GameObject.FindGameObjectWithTag("DamageIndicatorPooler").GetComponent<Pooler>();
        player = GameObject.FindGameObjectWithTag("Player");
        gameObject.transform.parent = player.transform;
        rotateSpeed = 0f;
        StartCoroutine(DestroyDemons());
     
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(player.transform.position, Vector3.back, rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Enemy"))
        {
            GameObject damageIndicator = damageIndicatorPool.GetObject();
            damageIndicator.transform.position = transform.position;
            damageIndicator.SetActive(true);
            //Instantiate(strikeParticles, transform.position, Quaternion.identity);
            other.gameObject.GetComponent<EnemyController>().HitSmall();


        }
    
    }

    public IEnumerator DestroyDemons()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

}