using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellsChickenItem : MonoBehaviour
{
    GameObject player;
    public GameObject itemStorage;

    public bool text;
    public int cost;

    public float demonChickenCoolDown;
    public bool itemGrabbed;

    public GameObject demonChicken;
    public GameObject demonChickenSummon;
    //public Animator animator;
    public bool allowSummon;
    private int killSave;
    private Vector2 itemMove1;
    private Vector2 itemMove2;
    public float itemSpeed;


    // Start is called before the first frame update
    void Start()
    {
        demonChickenCoolDown = 15f;
        cost = 0;
        itemStorage = GameObject.FindGameObjectWithTag("ItemStorage");
        player = GameObject.FindGameObjectWithTag("Player");
        itemGrabbed = false;
        text = false;


        allowSummon = true;
        killSave = GameManager.killCount;

        itemSpeed = 4f;
        StartCoroutine(ItemFloat());
        itemMove1 = new Vector3(transform.position.x, transform.position.y + 4, 0);
        itemMove2 = new Vector3(transform.position.x, transform.position.y - 4, 0);

    }

    public IEnumerator ItemFloat()
    {
        while (itemGrabbed == false)
        {
            yield return new WaitForSeconds(1.5f);
            transform.position = Vector3.MoveTowards(transform.position, itemMove1, itemSpeed * Time.deltaTime);
            yield return new WaitForSeconds(1f);
            transform.position = Vector3.MoveTowards(transform.position, itemMove2, itemSpeed * Time.deltaTime);


        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlayerInRange())
        {
            text = true;
        }
        else
        {
            text = false;
        }
        if (Input.GetKeyDown(KeyCode.E) && IsPlayerInRange() && GameManager.coinCount >= cost)
        {
            itemGrabbed = true;
            GameManager.itemsGrabbed++;
            GameManager.coinCount -= cost;
            //GetComponent<SpriteRenderer>().enabled = false;

            foreach (Transform child in gameObject.transform)
            {
                child.GetComponent<SpriteRenderer>().enabled = false;
            }
            gameObject.transform.parent = player.transform;
            if (GameManager.itemsGrabbed < 9)
            {
                gameObject.transform.position = new Vector3(itemStorage.transform.position.x, itemStorage.transform.position.y - GameManager.itemsGrabbed, -4);
            }
            else
            {
                gameObject.transform.position = new Vector3(itemStorage.transform.position.x + 1, itemStorage.transform.position.y + 8 - GameManager.itemsGrabbed, -4);
            }

        }


        if (itemGrabbed == true && allowSummon == true && (GameManager.killCount - killSave > 15))
        {
            Instantiate(demonChickenSummon, player.transform.position, Quaternion.identity);
            Instantiate(demonChicken, new Vector3(player.transform.position.x -1, player.transform.position.y +1,0), Quaternion.identity);
            Instantiate(demonChicken, new Vector3(player.transform.position.x, player.transform.position.y - 1, 0), Quaternion.identity);
            Instantiate(demonChicken, new Vector3(player.transform.position.x + 1, player.transform.position.y + 1, 0), Quaternion.identity);
           
            allowSummon = false;
            
            StartCoroutine(SummonCoolDown());
        }
        

    }

    public bool IsPlayerInRange()
    {
        return Vector3.Distance(transform.position, player.transform.position) <= 1.5;
    }

    public IEnumerator SummonCoolDown()
    {


        yield return new WaitForSeconds(demonChickenCoolDown);
        killSave = GameManager.killCount;
        allowSummon = true;
        
    }



}