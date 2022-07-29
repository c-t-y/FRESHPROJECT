using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Upgrades : MonoBehaviour
{
    //public Button firstChoice;
    //public Button secondChoice;
    //public Button thirdChoice;
    public GameObject upgradeFirstButton;

    public TextMeshProUGUI firstChoiceText;
    public TextMeshProUGUI secondChoiceText;
    public TextMeshProUGUI thirdChoiceText;
    public TextMeshProUGUI fourthChoiceText;

    public GameObject player;

    public string[] upgrades =
    {
        "Speed Up",
        "Fire Rate Up",
        "Damage Up",
        "Max Health Up"
    };

    public void Shuffle(string[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            string tmp = array[i];
            int rand = Random.Range(0, array.Length);
            array[i] = array[rand];
            array[rand] = tmp;
        }
        firstChoiceText.text = upgrades[0];
        secondChoiceText.text = upgrades[1];
        thirdChoiceText.text = upgrades[2];
        fourthChoiceText.text = upgrades[3];

    }

    // Start is called before the first frame update
    void Start()
    {
        Shuffle(upgrades);
        //foreach (var upgrade in upgrades)
        //{
        //    Debug.Log(upgrade);
        //}
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FirstChoice()
    {
        Debug.Log("first choice clicked");

        if (firstChoiceText.text == "Speed Up")
        {
            player.GetComponent<PlayerController>().playerSpeed += 1;
        }

        else if (firstChoiceText.text == "Fire Rate Up")
        {
            player.GetComponent<PlayerController>().fireRate *= 0.9f;
        }

        else if (firstChoiceText.text == "Damage Up")
        {
            player.GetComponent<PlayerController>().playerDamage *= 1.1f;
        }

        else if (firstChoiceText.text == "Max Health Up")
        {
            GameManager.maxHealth += 5;
            player.GetComponent<PlayerController>().Heal(5);
        }

        Time.timeScale = 1;
        gameObject.SetActive(false);
        Shuffle(upgrades);

    }
    public void SecondChoice()
    {
        Debug.Log("second choice clicked");

        if (secondChoiceText.text == "Speed Up")
        {
            player.GetComponent<PlayerController>().playerSpeed += 1;
        }

        else if (secondChoiceText.text == "Fire Rate Up")
        {
            player.GetComponent<PlayerController>().fireRate *= 0.9f;
        }

        else if (secondChoiceText.text == "Damage Up")
        {
            player.GetComponent<PlayerController>().playerDamage *= 1.1f;
        }

        else if (secondChoiceText.text == "Max Health Up")
        {
            GameManager.maxHealth += 5;
            player.GetComponent<PlayerController>().Heal(5);
        }

        Time.timeScale = 1;
        gameObject.SetActive(false);
        Shuffle(upgrades);

    }
    public void ThirdChoice()
    {
        Debug.Log("third choice clicked");

        if (thirdChoiceText.text == "Speed Up")
        {
            player.GetComponent<PlayerController>().playerSpeed += 1;
        }

        else if (thirdChoiceText.text == "Fire Rate Up")
        {
            player.GetComponent<PlayerController>().fireRate *= 0.9f;
        }

        else if (thirdChoiceText.text == "Damage Up")
        {
            player.GetComponent<PlayerController>().playerDamage *= 1.1f;
        }

        else if (thirdChoiceText.text == "Max Health Up")
        {
            GameManager.maxHealth += 5;
        }

        Time.timeScale = 1;
        gameObject.SetActive(false);
        Shuffle(upgrades);

    }
    public void FourthChoice()
    {
        Debug.Log("fourth choice clicked");

        if (fourthChoiceText.text == "Speed Up")
        {
            player.GetComponent<PlayerController>().playerSpeed += 1;
        }

        else if (fourthChoiceText.text == "Fire Rate Up")
        {
            player.GetComponent<PlayerController>().fireRate *= 0.9f;
        }

        else if (fourthChoiceText.text == "Damage Up")
        {
            player.GetComponent<PlayerController>().playerDamage *= 1.1f;
        }

        else if (fourthChoiceText.text == "Max Health Up")
        {
            GameManager.maxHealth += 5;
        }

        Time.timeScale = 1;
        gameObject.SetActive(false);
        Shuffle(upgrades);

    }


}
