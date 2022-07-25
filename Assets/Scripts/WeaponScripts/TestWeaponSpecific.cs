using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWeaponSpecific : MonoBehaviour
{

    public WeaponController playerWeaponController;

    private void Start()
    {
        playerWeaponController = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponController>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerWeaponController.fireRate = 0.2f;
            playerWeaponController.bulletSpeed = 200;
            Destroy(gameObject);

        }
    }
}
