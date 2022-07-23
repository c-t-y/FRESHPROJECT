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
        player = GameObject.FindGameObjectWithTag("Player");
        loot = GetComponent<LootScript>();
    }

    public void Hit()
    {
        if ((health -= player.GetComponent<PlayerController>().playerDamage) <= 0)
        {
            Death();
        }
        else
        {

            health -= player.GetComponent<PlayerController>().playerDamage;
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
