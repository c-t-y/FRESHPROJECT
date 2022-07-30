using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    LootScript loot;
    GameObject player;
    GameObject xpBar;
    SpriteRenderer spriteRenderer;
    public GameObject damageIndication;
    public EnemyScriptableObject EnemyScriptableObject;
    private UnityEngine.Object explosionRef;


    private bool coolDownAttack = false;
    public float range;
    public float speed;
    public float currentHealth;
    public float maxHealth;
    public float attackRange;
    public float coolDown;
    public float attackDamage;

    void Start()
    {
        explosionRef = Resources.Load("Explode");
        EnemySetup();
        player = GameObject.FindGameObjectWithTag("Player");
        xpBar = GameObject.FindGameObjectWithTag("XPBar");
        spriteRenderer = GetComponent<SpriteRenderer>();
        loot = GetComponent<LootScript>();
    }

    public void EnemySetup()
    {
        currentHealth = EnemyScriptableObject.eHealth;
        range = EnemyScriptableObject.eRange;
        speed = EnemyScriptableObject.eSpeed;
        attackRange = EnemyScriptableObject.eAttackRng;
        coolDown = EnemyScriptableObject.eAttackCD;
        attackDamage = EnemyScriptableObject.eAttackDmg;

    }

    void Update()
    {

        if (Vector3.Distance(transform.position, player.transform.position) <= attackRange)
        {
            Attack();
        }
    }

    public bool IsPlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, player.transform.position) <= range;
    }


    void Attack()
    {
        if (!coolDownAttack && player.GetComponent<PlayerController>().canTakeDmg == true)
        {
            player.GetComponent<PlayerController>().TakeDamage(attackDamage);
            StartCoroutine(CoolDown());
        }

    }
    IEnumerator CoolDown()
    {
        coolDownAttack = true;
        yield return new WaitForSeconds(coolDown);
        coolDownAttack = false;
    }


    //Damage on Hit Scripts
    public void HitXL()
    {
        StartCoroutine(FlashRed());
        currentHealth -= player.GetComponent<PlayerController>().calcPlayerDamageXL;
        if ((currentHealth <= 0))
        {
            Death();
        }
    }

    public void HitLarge()
    {
        StartCoroutine(FlashRed());
        currentHealth -= player.GetComponent<PlayerController>().calcPlayerDamageLarge;
        if ((currentHealth <= 0))
        {
            Death();
        }
    }
    public void Hit()
    {
        StartCoroutine(FlashRed());
        currentHealth -= player.GetComponent<PlayerController>().calcPlayerDamage;
        if ((currentHealth <= 0))
        {
            Death();
        }
    }
    public void HitSmall()
    {
        StartCoroutine(FlashRed());
        currentHealth -= player.GetComponent<PlayerController>().calcPlayerDamageSmall;
        if ((currentHealth <= 0))
        {
            Death();
        }
    }
    public void HitXS()
    {
        StartCoroutine(FlashRed());
        currentHealth -= player.GetComponent<PlayerController>().calcPlayerDamageXS;
        if ((currentHealth <= 0))
        {
            Death();
        }
    }
 



    public void Death()
    {
        GameObject explosion = (GameObject)Instantiate(explosionRef);
        explosion.transform.position = new Vector3(transform.position.x, transform.position.y + .3f, transform.position.z);

        xpBar.GetComponent<XPBar>().GainXP(1);
        Destroy(gameObject);
        GameManager.killCount += 1;
        loot.GetComponent<LootScript>().calculateLoot();


    }
    public IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }
}
