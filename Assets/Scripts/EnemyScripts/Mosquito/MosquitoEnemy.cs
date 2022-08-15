using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MosquitoEnemy : MonoBehaviour
{
    public GameObject player;
    public EnemyController enemyController;
    public SpriteRenderer spriteRenderer;
    private Vector2 newTargetPosition;

    public string currState;
    public float range;
    private bool chooseDir = false;
    private Vector2 randomDir;
    private int randX;
    private int randY;
    private int randWait;

    public float eSpeed = 3f;


    private void Start()
    {
        currState = "Wander";
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyController = GetComponent<EnemyController>();
        StartCoroutine(UpdateTarget());
    }

    private IEnumerator UpdateTarget()
    {
        while (true)
        {
            randX = Random.Range(-4, 4);
            randY = Random.Range(-4, 4);
            randWait = Random.Range(3, 4);
            newTargetPosition = new Vector3(player.transform.position.x + randX, player.transform.position.y + randY, 0);
            yield return new WaitForSeconds(randWait);
        }
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

        transform.position = Vector3.MoveTowards(transform.position, newTargetPosition, eSpeed * Time.deltaTime);

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
