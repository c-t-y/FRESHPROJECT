using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggMineItem : MonoBehaviour
{
    GameObject player;
    public GameObject itemStorage;

    public bool text;
    public int cost;
    public GameObject eggMine;
   
    public bool itemGrabbed;

    // Start is called before the first frame update
    void Start()
    {
        itemStorage = GameObject.FindGameObjectWithTag("ItemStorage");
        cost = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        itemGrabbed = false;
        text = false;

      
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
            ActivateItem();
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
    }
    public bool IsPlayerInRange()
    {
        return Vector3.Distance(transform.position, player.transform.position) <= 1.5;
    }

    public void ActivateItem()
    {
        if (itemGrabbed == true)
        {
            InvokeRepeating("ApplyItemEffect", 3f, 3f);
        }
    }
    public void ApplyItemEffect()
    {
       
        Instantiate(eggMine, player.transform.position, Quaternion.identity);
        
    }
}