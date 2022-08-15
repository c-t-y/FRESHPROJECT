using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using EZCameraShake;

public class EggMineObject : MonoBehaviour
{

    public float lifeTime = 3f;
    public GameObject player;
    public Pooler damageIndicatorPool;



    // Start is called before the first frame update
    void Start()
    {
        damageIndicatorPool = GameObject.FindGameObjectWithTag("DamageIndicatorPooler").GetComponent<Pooler>();
        GetComponent<Collider2D>().enabled = false;
        InvokeRepeating("Explode", lifeTime, .1f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Explode()
    {
        GetComponent<Collider2D>().enabled = true;
        //CameraShaker.Instance.ShakeOnce(3f, 2f, .05f, .3f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Enemy"))
        {
            GameObject damageIndicator = damageIndicatorPool.GetObject();
            damageIndicator.transform.position = transform.position;
            damageIndicator.SetActive(true);

            other.gameObject.GetComponent<EnemyController>().Hit();

            Destroy(gameObject);
        }
        if (other.CompareTag("Object"))
        {
            other.gameObject.GetComponent<ObjectController>().Hit();

            Destroy(gameObject);

        }

    }


}
