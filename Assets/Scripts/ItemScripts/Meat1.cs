using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat1 : MonoBehaviour
{
    public int coinValue;
    public GameObject player;
    private void Start()
    {
        coinValue = 1;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            Destroy(gameObject);
            GameManager.coinCount += coinValue;
            Debug.Log("meat 1 picked up");
        }

    }
}
