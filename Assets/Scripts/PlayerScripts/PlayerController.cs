using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    //public GameObject bulletPrefab;
    public HealthBar healthBar;
    public GameObject deathScreen;
    public Animator animator;
    public float calcPlayerDamage;

    // base player stats
    public float bulletSpeed;
    public float fireRate;
    public float bulletSpread = .3f;
    public float currentHealth;
    public float playerDamage;
    public float playerSpeed;




    // Start is called before the first frame update
    void Start()
    {
        playerDamage = StatsEnemy.eHealth * 0.25f;
        currentHealth = GameManager.maxHealth;
        healthBar.SetMaxHealth(GameManager.maxHealth);



        rb = GetComponent<Rigidbody2D>();
        //allowFire = true;
    }
    void FixedUpdate()
    {
        // new movement input
        if (Input.GetAxisRaw("Horizontal") > 0.1)
        {
            rb.velocity = new Vector2(playerSpeed, rb.velocity.y);
        }
        else if (Input.GetAxisRaw("Horizontal") < -0.1)
        {
            rb.velocity = new Vector2(-playerSpeed, rb.velocity.y);
        }
        else if (Input.GetAxisRaw("Horizontal") == 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (Input.GetAxisRaw("Vertical") > 0.1)
        {
            rb.velocity = new Vector2(rb.velocity.x, playerSpeed);
        }
        else if (Input.GetAxisRaw("Vertical") < -0.1)
        {
            rb.velocity = new Vector2(rb.velocity.x, -playerSpeed);
        }
        else if (Input.GetAxisRaw("Vertical") == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }

    }
    // Update is called once per frame
    void Update()
    {
        calcPlayerDamage = Mathf.Ceil(playerDamage);
        animator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("Speed", rb.velocity.sqrMagnitude);



        //check death
        if (currentHealth <= 0)
        {
            Death();
        }
    }
    //void Shoot(string direction)
    //{
    //    float randBullet = Random.Range(-bulletSpread, bulletSpread);

    //    if (direction == "up")
    //    {

    //        var bulletInstance = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
    //        bulletInstance.GetComponent<Rigidbody2D>().AddForce(new Vector3(randBullet, 1, 0) * bulletSpeed);
    //    }
    //    if (direction == "down")
    //    {
    //        var bulletInstance = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
    //        bulletInstance.GetComponent<Rigidbody2D>().AddForce(new Vector3(randBullet, -1, 0) * bulletSpeed);
    //    }
    //    if (direction == "left")
    //    {
    //        var bulletInstance = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
    //        bulletInstance.GetComponent<Rigidbody2D>().AddForce(new Vector3(-1, randBullet, 0) * bulletSpeed);
    //    }
    //    if (direction == "right")
    //    {
    //        var bulletInstance = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
    //        bulletInstance.GetComponent<Rigidbody2D>().AddForce(new Vector3(1, randBullet, 0) * bulletSpeed);
    //    }
    //}

    //public IEnumerator FireCooldown()
    //{
    //    yield return new WaitForSeconds(fireRate);
    //    allowFire = true;
    //}

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    public void Heal(float damage)
    {
        if (currentHealth < GameManager.maxHealth)
        {
            currentHealth += damage;
        }
        else
        {
            currentHealth = GameManager.maxHealth;
        }
        healthBar.SetHealth(currentHealth);

    }
    public void Death()
    {
        deathScreen.SetActive(true);
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }


}


