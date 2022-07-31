using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatMomEnemy : MonoBehaviour
{
    public GameObject player;
    public EnemyController enemyController;
    public SpriteRenderer spriteRenderer;
    public GameObject ratBaby;

    public string currState;
    public float range;
    private bool chooseDir = false;
    private Vector2 randomDir;

    public static float eSpeed = 3f;


    private void Start()
    {
        currState = "Wander";
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyController = GetComponent<EnemyController>();

        InvokeRepeating("SpawnBabies", 3f, 5f);
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

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, eSpeed * Time.deltaTime);

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

    public void SpawnBabies()
    {
        Instantiate(ratBaby, transform.position, Quaternion.identity);

    }
}



