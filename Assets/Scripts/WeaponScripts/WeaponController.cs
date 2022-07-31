using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Animator animator;
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


        // animation check
        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    //animator.SetBool("ShootLeft", true);
        //}
        //if (Input.GetKeyUp(KeyCode.LeftArrow))
        //{
        //    //animator.SetBool("ShootLeft", false);
        //}
        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    animator.SetBool("ShootRight", true);
        //}
        //if (Input.GetKeyUp(KeyCode.RightArrow))
        //{
        //    animator.SetBool("ShootRight", false);
        //}
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
                animator.SetBool("ShootLeft", true);
                var bulletInstance = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
                bulletInstance.GetComponent<Rigidbody2D>().AddForce(new Vector3(-1, randBullet, 0) * bulletSpeed);


            }
            if (direction == "right")
            {
                animator.SetBool("ShootRight", true);
                var bulletInstance = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
                bulletInstance.GetComponent<Rigidbody2D>().AddForce(new Vector3(1, randBullet, 0) * bulletSpeed);

            }
        
    }
    public IEnumerator FireCooldown()
    {
        yield return new WaitForSeconds(fireRate);
        animator.SetBool("ShootLeft", false);
        animator.SetBool("ShootRight", false);
        allowFire = true;
    }


}
