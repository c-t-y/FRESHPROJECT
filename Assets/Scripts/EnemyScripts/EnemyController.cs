using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;
    LootScript loot;
    GameObject player;
    GameObject xpBar;
    public GameObject damageIndication;
    public EnemyScriptableObject EnemyScriptableObject;

    private bool coolDownAttack = false;

    public float range;
    public float speed;
    public float currentHealth;
    public float maxHealth;
    public float attackRange;
    public float coolDown;
    public float attackDamage;
    public float xp;


    void Start()
    {
        EnemySetup();
        player = GameObject.FindGameObjectWithTag("Player");
        xpBar = GameObject.FindGameObjectWithTag("XPBar");
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
        xp = EnemyScriptableObject.eXP;
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
    public void Hit()
    {
        currentHealth -= player.GetComponent<PlayerController>().calcPlayerDamage;
        if ((currentHealth <= 0))
        {
            Death();
        }
    }
    public void Attack()
    {
        if (!coolDownAttack)
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
    public void Death()
    {
        xpBar.GetComponent<XPBar>().GainXP(xp);
        Destroy(gameObject);
        GameManager.killCount += 1;
        loot.GetComponent<LootScript>().calculateLoot();
    }
}
