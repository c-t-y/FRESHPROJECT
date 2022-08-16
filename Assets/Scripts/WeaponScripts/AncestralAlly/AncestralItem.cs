using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AncestralItem : MonoBehaviour
{
    GameObject player;
    public GameObject itemStorage;

    public bool text;
    public int cost;

    public float allyEggCoolDown;
    public bool itemGrabbed;

    public GameObject allyEgg;
    //public Animator animator;
    public bool allowEgg;



    // Start is called before the first frame update
    void Start()
    {
        allyEggCoolDown = 10f;
        cost = 0;
        itemStorage = GameObject.FindGameObjectWithTag("ItemStorage");
        player = GameObject.FindGameObjectWithTag("Player");
        itemGrabbed = false;
        text = false;
       

        allowEgg = true;

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

       

        if(itemGrabbed == true && allowEgg == true)
        {
           Instantiate(allyEgg, player.transform.position, Quaternion.identity);
           allowEgg = false;
           StartCoroutine(AllyEggCooldown());
        }
    }

        public bool IsPlayerInRange()
        {
            return Vector3.Distance(transform.position, player.transform.position) <= 1.5;
        }

    public IEnumerator AllyEggCooldown()
    {
        if (itemGrabbed == true && GameObject.FindGameObjectWithTag("AncestralEgg") == null)
        {
            yield return new WaitForSeconds(allyEggCoolDown);

            allowEgg = true;
        }
    }



}