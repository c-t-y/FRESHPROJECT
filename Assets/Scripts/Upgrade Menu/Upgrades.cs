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

}
