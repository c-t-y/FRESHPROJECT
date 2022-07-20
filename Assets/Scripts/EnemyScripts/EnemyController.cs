using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyState
{
    Wander,
    Follow,
    Attack,
    Die
};


public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;
    LootScript loot;
    GameObject player;
    GameObject xpBar;
    public EnemyState currState = EnemyState.Wander;

    public float range;
    public float speed;
    private bool chooseDir = false;
    private Vector2 randomDir;
    public float health = 10f;
    public float attackRange;
    private bool coolDownAttack = false;
    public float coolDown;
    public float attackDamage = 1f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        xpBar = GameObject.FindGameObjectWithTag("XPBar");
        loot = GetComponent<LootScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (currState == EnemyState.Wander)
        {
            Wander();
        }
        else if (currState == EnemyState.Follow)
        {
            Follow();
        }
        else if (currState == EnemyState.Die)
        {
            Death();
        }
        else if (currState == EnemyState.Attack)
        {
            Attack();
        }



        if (IsPlayerInRange(range) && currState != EnemyState.Die)
        {
            currState = EnemyState.Follow;
        }
        else if (!IsPlayerInRange(range) && currState != EnemyState.Die)
        {
            currState = EnemyState.Wander;
        }
        // attack player
        if (Vector3.Distance(transform.position, player.transform.position) <= attackRange)
        {
            currState = EnemyState.Attack;
        }
    }

    private bool IsPlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, player.transform.position) <= range;
    }
    private IEnumerator ChooseDirection()
    {
        chooseDir = true;
        yield return new WaitForSeconds(Random.Range(2f, 8f));
        randomDir = new Vector2(0, Random.Range(0, 360));
        Quaternion nextRotation = Quaternion.Euler(randomDir);
        //transform.rotation = Quaternion.Lerp(transform.rotation, nextRotation, Random.Range(0.5f, 2.5f));
        chooseDir = false;
    }
    void Wander()
    {
        if (!chooseDir)
        {
            StartCoroutine(ChooseDirection());
        }

        transform.position += -transform.right * speed * Time.deltaTime;
        if (IsPlayerInRange(range))
        {
            currState = EnemyState.Follow;
        }

    }

    void Attack()
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
    void Follow()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    public void Hit()
    {
        if ((health -= player.GetComponent<PlayerController>().playerDamage) <= 0)
        {
            Death();
        }
        else
        {

            health -= player.GetComponent<PlayerController>().playerDamage;
        }
    }
    public void Death()
    {
        xpBar.GetComponent<XPBar>().GainXP(1);
        Destroy(gameObject);
        GameManager.killCount += 1;
        loot.GetComponent<LootScript>().calculateLoot();


    }
}
