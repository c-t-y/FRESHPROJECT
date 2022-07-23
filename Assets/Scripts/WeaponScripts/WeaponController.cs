using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public bool allowFire;
    public float bulletSpread = .3f;
    public float bulletSpeed;
    public float fireRate;

    // Start is called before the first frame update
    void Start()
    {
        allowFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        //shooting input
        if (Input.GetKey(KeyCode.UpArrow) && allowFire == true)
        {

            Shoot("up");
            allowFire = false;
            StartCoroutine(FireCooldown());

        }
        if (Input.GetKey(KeyCode.DownArrow) && allowFire == true)
        {
            Shoot("down");
            allowFire = false;
            StartCoroutine(FireCooldown());

        }
        if (Input.GetKey(KeyCode.LeftArrow) && allowFire == true)
        {
            Shoot("left");
            allowFire = false;
            StartCoroutine(FireCooldown());

        }
        if (Input.GetKey(KeyCode.RightArrow) && allowFire == true)
        {
            Shoot("right");
            allowFire = false;
            StartCoroutine(FireCooldown());

        }
    }

    void Shoot(string direction)
    {
        float randBullet = Random.Range(-bulletSpread, bulletSpread);

        if (direction == "up")
        {

            var bulletInstance = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody2D>().AddForce(new Vector3(randBullet, 1, 0) * bulletSpeed);
        }
        if (direction == "down")
        {
            var bulletInstance = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody2D>().AddForce(new Vector3(randBullet, -1, 0) * bulletSpeed);
        }
        if (direction == "left")
        {
            var bulletInstance = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody2D>().AddForce(new Vector3(-1, randBullet, 0) * bulletSpeed);
        }
        if (direction == "right")
        {
            var bulletInstance = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody2D>().AddForce(new Vector3(1, randBullet, 0) * bulletSpeed);
        }
    }
    public IEnumerator FireCooldown()
    {
        yield return new WaitForSeconds(fireRate);
        allowFire = true;
    }


}
