using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    //public GameObject bulletPrefab;
    public HealthBar healthBar;
    public GameObject deathScreen;
    public Animator animator;
    public SpriteRenderer spriteRenderer;


    public float calcPlayerDamageXL;
    public float calcPlayerDamageLarge;
    public float calcPlayerDamage;
    public float calcPlayerDamageSmall;
    public float calcPlayerDamageXS;


    public float dmgCooldown;
    public bool canTakeDmg;

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
        canTakeDmg = true;
        dmgCooldown = 0.5f;
        playerDamage = StatsEnemy.eHealth * 0.25f;
        currentHealth = GameManager.maxHealth;
        healthBar.SetMaxHealth(GameManager.maxHealth);
        spriteRenderer = GetComponent<SpriteRenderer>();



        rb = GetComponent<Rigidbody2D>();
        //allowFire = true;
    }
    void FixedUpdate()
    {
        // new movement input
        if (Input.GetAxisRaw("HorizontalMovement") > 0.1)
        {
            rb.velocity = new Vector2(playerSpeed, rb.velocity.y);
        }
        else if (Input.GetAxisRaw("HorizontalMovement") < -0.1)
        {
            rb.velocity = new Vector2(-playerSpeed, rb.velocity.y);
        }
        else if (Input.GetAxisRaw("HorizontalMovement") == 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (Input.GetAxisRaw("VerticalMovement") > 0.1)
        {
            rb.velocity = new Vector2(rb.velocity.x, playerSpeed);
        }
        else if (Input.GetAxisRaw("VerticalMovement") < -0.1)
        {
            rb.velocity = new Vector2(rb.velocity.x, -playerSpeed);
        }
        else if (Input.GetAxisRaw("VerticalMovement") == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }

    }
    // Update is called once per frame
    void Update()
    {
        calcPlayerDamageXL = Mathf.Ceil(playerDamage * 4f);
        calcPlayerDamageLarge = Mathf.Ceil(playerDamage * 2f);
        calcPlayerDamage = Mathf.Ceil(playerDamage);
        calcPlayerDamageSmall = Mathf.Ceil(playerDamage * 0.5f);
        calcPlayerDamageXS = Mathf.Ceil(playerDamage * 0.25f);

        animator.SetFloat("Horizontal", Input.GetAxisRaw("HorizontalMovement"));
        animator.SetFloat("Vertical", Input.GetAxisRaw("VerticalMovement"));
        animator.SetFloat("Speed", rb.velocity.sqrMagnitude);



        //check death
        if (currentHealth <= 0)
        {
            Death();
        }
    }


    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        canTakeDmg = false;
        healthBar.SetHealth(currentHealth);
        CameraShaker.Instance.ShakeOnce(8f, 4f, .05f, .3f);
        StartCoroutine(FlashRed());
        StartCoroutine(TakeDamageCooldown());

    }
    IEnumerator TakeDamageCooldown()
    {
        yield return new WaitForSeconds(dmgCooldown);
        canTakeDmg = true;

    }


    public void Heal(float hp)
    {
        if (currentHealth < GameManager.maxHealth)
        {
            if (currentHealth + hp > GameManager.maxHealth)
            {
                currentHealth = GameManager.maxHealth;
            }
            else
            {
                currentHealth += hp;
            }

        }
        else
        {
            return;
        }
        healthBar.SetHealth(currentHealth);

    }
    public void Death()
    {
        deathScreen.SetActive(true);
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }


    public IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }



}


