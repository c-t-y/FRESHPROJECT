using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HawkEnemy : MonoBehaviour
{
    public GameObject player;
    public EnemyController enemyController;
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites; 


    public string currState;
    public float range;
    private bool chooseDir = false;
    private Vector2 randomDir;

    public float eSpeed = 3f;
    public float rotateSpeed;


    private float calcDist;

    private bool coolDownAttack = false;

    public float attackRangeHawk;
    public float coolDownHawk;
    public float attackDamageHawk;

    public bool landed;
    public bool resetMove;
    public bool groundMode;

    public Animator animator;

    private void Start()
    {
        currState = "Wander";
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyController = GetComponent<EnemyController>();
        animator = GetComponent<Animator>();

        GetComponent<Collider2D>().enabled = false;


        resetMove = false;
        landed = false;
        groundMode = false;
        animator.enabled = false;

        //InvokeRepeating("TargetUpdate",0,2);

        eSpeed = 1f;
        rotateSpeed = 700f;

        attackRangeHawk = 1f;
        coolDownHawk = 3f;
        attackDamageHawk = 2f;

    }


    private void Update()
    {
        spriteRenderer.flipX = player.transform.position.x < transform.position.x;

        if (currState == "Wander" && !GameManager.playerInShop)
        {
            Wander();
        }
        else if (currState == "Follow" && !GameManager.playerInShop)
        {
            Follow();
        }

        if (resetMove == false && enemyController.IsPlayerInRange(range))
        {
            currState = "Follow";
        }
        else if (!enemyController.IsPlayerInRange(range))
        {
            currState = "Wander";
        }

        if( landed == true)
        {
            eSpeed = 0f;
        }
        calcDist = Vector2.Distance(player.transform.position, transform.position);
        if (landed == false )
        { 
            if (calcDist > range)
            {
                eSpeed = 1f;
            }
            else
            {
                eSpeed = 1 / (calcDist / range) * 0.75f;
            }
        }

        if (groundMode == false)
        {
            if (calcDist < 1)
            {
                spriteRenderer.sprite = sprites[4];
            }
            else if (calcDist < 1.25)
            {
                spriteRenderer.sprite = sprites[3];
            }
            else if (calcDist < 1.5)
            {
                spriteRenderer.sprite = sprites[2];
            }
            else if (calcDist < 1.75)
            {
                spriteRenderer.sprite = sprites[1];
            }
            else if (calcDist >= 1.75)
            {
                spriteRenderer.sprite = sprites[0];
            }
        }
        else
        {
            animator.enabled = true;
        }


        if (Vector3.Distance(transform.position, player.transform.position) <= attackRangeHawk)
        {
            StartCoroutine(FlightStatus());
        }
    }

    public IEnumerator FlightStatus()
    {
        landed = true;
        groundMode = true;
        GetComponent<Collider2D>().enabled = true;
        yield return new WaitForSeconds(.5f);
        if (Vector3.Distance(transform.position, player.transform.position) <= attackRangeHawk)
        {
            Attack();
        }
        yield return new WaitForSeconds(2f);
        //StartCoroutine(LiftOff());
        landed = false;
    }

    //public IEnumerator LiftOff()
    //{
        //resetMove = true;
        //Wander();
        //yield return new WaitForSeconds(3f);
        //resetMove = false;

    //}

    void Attack()
    {
        if (!coolDownAttack && landed == true && player.GetComponent<PlayerController>().canTakeDmg == true)
        {
            player.GetComponent<PlayerController>().TakeDamage(attackDamageHawk);
            StartCoroutine(CoolDown());
        }

    }

    IEnumerator CoolDown()
    {
        coolDownAttack = true;
        yield return new WaitForSeconds(coolDownHawk);
        coolDownAttack = false;
    }

    void Wander()
    {
        if (!chooseDir)
        {
            StartCoroutine(ChooseDirection());
        }

        transform.position += -transform.right * eSpeed * Time.deltaTime;
        if (enemyController.IsPlayerInRange(range))
        {
            currState = "Follow";
        }
    }



    void Follow()
    {

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, eSpeed * Time.deltaTime);
        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        if (groundMode == false)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, Time.deltaTime * rotateSpeed);
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }

    }


    public IEnumerator ChooseDirection()
    {
        chooseDir = true;
        yield return new WaitForSeconds(Random.Range(2f, 8f));
        randomDir = new Vector2(0, Random.Range(0, 360));
        Quaternion nextRotation = Quaternion.Euler(randomDir);
        //transform.rotation = Quaternion.Lerp(transform.rotation, nextRotation, Random.Range(0.5f, 2.5f));
        chooseDir = false;
    }



}









