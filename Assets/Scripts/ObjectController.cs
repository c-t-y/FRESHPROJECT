using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public GameObject bullet;
    LootScript loot;
    GameObject player;


    public float health = 10f;
 

    // Start is called before the first frame update
    void Start()
    {
        loot = GetComponent<LootScript>();
    }

    public void Hit()
    {
        if ((health -= bullet.GetComponent<BulletController>().bulletDamage) <= 0)
        {
            Death();
        }
        else
        {

            health -= bullet.GetComponent<BulletController>().bulletDamage;
        }
    }
    public void Death()
    {
        Destroy(gameObject);
        loot.GetComponent<LootScript>().calculateLoot();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
