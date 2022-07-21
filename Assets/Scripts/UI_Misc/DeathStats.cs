using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathStats : MonoBehaviour
{
    public TextMeshProUGUI damageDealt;
    public TextMeshProUGUI coinsCollected;
    public TextMeshProUGUI enemiesDefeated;
    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        coinsCollected.text = "Coins collected: " + GameManager.coinCount.ToString();
        enemiesDefeated.text = "Enemies Defeated: " + GameManager.killCount.ToString();

    }
}
