using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat3 : MonoBehaviour
{
    public int coinValue;
    public GameObject player;
    private void Start()
    {
        coinValue = 7;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if (IsPlayerInRange(2))
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
        GameManager.coinCount += coinValue;
        Debug.Log("meat 2 picked up");
        Destroy(gameObject);
    }
}
