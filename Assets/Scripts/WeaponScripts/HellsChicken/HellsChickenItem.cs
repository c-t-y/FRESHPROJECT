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
            gameObject.transform.parent = player.transform;
            if (GameManager.itemsGrabbed < 8)
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