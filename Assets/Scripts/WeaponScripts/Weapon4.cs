using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon4 : MonoBehaviour
{
    GameObject player;
    WeaponController playerWeaponController;
    GameObject text;
    public int cost;

    // Start is called before the first frame update
    void Start()
    {
        cost = 6;
        player = GameObject.FindGameObjectWithTag("Player");
        playerWeaponController = player.GetComponent<WeaponController>();
        text = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlayerInRange())
        {
            text.SetActive(true);
        }
        else
        {
            text.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.E) && IsPlayerInRange() && GameManager.coinCount >= cost)
        {
            ApplyItemEffect();
            GameManager.coinCount -= cost;
            Destroy(gameObject);
        }
    }
    public bool IsPlayerInRange()
    {
        return Vector3.Distance(transform.position, player.transform.position) <= 1.5;
    }
    void ApplyItemEffect()
    {
        playerWeaponController.fireRate += 0.1f;
        playerWeaponController.bulletSpeed += 500;
    }
}
