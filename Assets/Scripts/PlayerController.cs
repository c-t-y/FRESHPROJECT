using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject bulletPrefab;
    public HealthBar healthBar;
    public float playerSpeed;
    public bool allowFire;
    public float bulletSpeed;
    public float fireRate;
    public float currentHealth;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = GameManager.maxHealth;
        healthBar.SetMaxHealth(GameManager.maxHealth);

        rb = GetComponent<Rigidbody2D>();
        allowFire = true;
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1f);

        }

        // movement input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(horizontal * playerSpeed, vertical * playerSpeed, 0);


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
        if (direction == "up")
        {

            var bulletInstance = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody2D>().AddForce(Vector3.up * bulletSpeed);
        }
        if (direction == "down")
        {
            var bulletInstance = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody2D>().AddForce(Vector3.down * bulletSpeed);
        }
        if (direction == "left")
        {
            var bulletInstance = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody2D>().AddForce(Vector3.left * bulletSpeed);
        }
        if (direction == "right")
        {
            var bulletInstance = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody2D>().AddForce(Vector3.right * bulletSpeed);
        }
    }

    public IEnumerator FireCooldown()
    {
        yield return new WaitForSeconds(fireRate);
        allowFire = true;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }


}


