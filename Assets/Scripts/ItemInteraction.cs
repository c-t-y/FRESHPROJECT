using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    public GameObject player;
    public GameObject gameManager;
    private string coinName;
    public int coinValue;
    private string healthName;
    public int healthValue;
    public float currentHealth;
    public HealthBar healthBar;
    public bool allowHeal;

    private int collidedCoinValue;
    private int collidedHealthValue;


    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindGameObjectWithTag("GameManager");

        coinName = name.Substring(0, 5);

        switch (coinName)
        {
            case "Coin1":
                coinValue = 1;
                break;
            case "Coin2":
                coinValue = 4;
                break;
            case "Coin3":
                coinValue = 7;
                break;

        }



    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);

            collidedCoinValue = coinValue;
            gameManager.GetComponent<GameManager>().coinCount += collidedCoinValue;

            //collidedHealthValue = healthValue;
            //currentHealth += healthValue;
            //healthBar.SetHealth(currentHealth);
            if (allowHeal == true)
            {
                player.GetComponent<PlayerController>().Heal(3);
            }
        }
    }
}
