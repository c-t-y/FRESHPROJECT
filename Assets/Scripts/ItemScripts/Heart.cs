using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public int healValue;
    public GameObject player;
    private void Start()
    {
        healValue = 5;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player && GameManager.maxHealth != player.GetComponent<PlayerController>().currentHealth)
        {
            Destroy(gameObject);
            player.GetComponent<PlayerController>().Heal(healValue);
            Debug.Log("heart picked up");
        }

    }
}
