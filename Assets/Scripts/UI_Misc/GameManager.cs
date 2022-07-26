using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static int killCount;
    public static int coinCount;
    public static int bombCount;
    public static bool playerInShop;

    public static float maxHealth = 10f;

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
