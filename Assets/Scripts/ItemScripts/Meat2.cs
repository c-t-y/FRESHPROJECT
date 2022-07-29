using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat2 : MonoBehaviour
{
    public int coinValue;
    public GameObject player;
    private void Start()
    {
        coinValue = 4;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            Destroy(gameObject);
            GameManager.coinCount += coinValue;
            Debug.Log("meat 2 picked up");
        }

    }
}
