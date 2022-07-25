using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FrogEnemy : MonoBehaviour
{
    public GameObject player;
    public EnemyController enemyController;
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    public string currState;
    public float range;
    public float attackRange;
    private bool chooseDir = false;
    public bool frogCanJump;
    private Vector2 randomDir;

    public float coolDown;
    public float attackDamage;

    public static float eSpeed = 8f;


    private void Start()
    {
        currState = "Wander";
        frogCanJump = true;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        spriteRenderer.flipX = player.transform.position.x < transform.position.x;

        if (currState == "Wander")
        {
            Wander();
        }
        else if (currState == "Follow")
        {
            Follow();
        }

        if (enemyController.IsPlayerInRange(range))
        {
            currState = "Follow";
        }
        else if (!enemyController.IsPlayerInRange(range))
        {
            currState = "Wander";
        }
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
        if (frogCanJump)
        {
            animator.SetBool("isJumping", true);
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, eSpeed * Time.deltaTime);
            StartCoroutine(FrogJumpCooldown());
        }



    }
    public IEnumerator FrogJumpCooldown()
    {
        yield return new WaitForSeconds(0.3f);
        frogCanJump = false;
        animator.SetBool("isJumping", false);
        yield return new WaitForSeconds(2f);
        frogCanJump = true;
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


