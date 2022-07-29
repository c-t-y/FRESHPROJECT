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
    private void Update()
    {
        if (IsPlayerInRange(2) && GameManager.maxHealth != player.GetComponent<PlayerController>().currentHealth)
        {
            StartCoroutine(FlyTowardsPlayer());

        }
    }
    public bool IsPlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, player.transform.position) <= range;
    }
    IEnumerator FlyTowardsPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 10 * Time.deltaTime);
        yield return new WaitForSeconds(0.5f);
        player.GetComponent<PlayerController>().Heal(healValue);
        Debug.Log("meat 2 picked up");
        Destroy(gameObject);
    }
}

