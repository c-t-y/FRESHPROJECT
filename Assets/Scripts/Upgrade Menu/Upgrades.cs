using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public Button firstChoice;
    public Button secondChoice;
    public Button thirdChoice;

    public GameObject player;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void FirstChoice()
    {
        Debug.Log("first choice clicked");
        player.GetComponent<PlayerController>().playerSpeed += 1;
        Time.timeScale = 1;
        gameObject.SetActive(false);

    }
    public void SecondChoice()
    {
        Debug.Log("second choice clicked");
        player.GetComponent<PlayerController>().fireRate -= 0.05f;
        Time.timeScale = 1;
        gameObject.SetActive(false);

    }
    public void ThirdChoice()
    {
        Debug.Log("third choice clicked");
        player.GetComponent<PlayerController>().playerDamage += StatsEnemy.eHealth * 0.25f;
        Time.timeScale = 1;
        gameObject.SetActive(false);

    }
    public void FourthChoice()
    {
        Debug.Log("fourth choice clicked");
        GameManager.maxHealth += 5;
        player.GetComponent<PlayerController>().Heal(5);
        Time.timeScale = 1;
        gameObject.SetActive(false);

    }


}
