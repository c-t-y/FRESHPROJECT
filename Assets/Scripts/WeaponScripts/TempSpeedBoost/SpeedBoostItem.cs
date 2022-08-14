using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostItem : MonoBehaviour
{
    GameObject player;
    public GameObject itemStorage;

    public bool text;
    public int cost;
    public bool itemGrabbed;

    public float boostAmount;
    public float abilityTimer;
    public float boostCoolDown;
    public float boostLength;

    // Start is called before the first frame update
    void Start()
    {
        boostCoolDown = 10f;
        boostLength = 3f;
        boostAmount = 3f;
        cost = 0;
        itemStorage = GameObject.FindGameObjectWithTag("ItemStorage");
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

        if( itemGrabbed == true && Time.time >= abilityTimer)
        {

            BoostEffect();
            abilityTimer = Time.time + boostCoolDown;
        }
      

    }

    private void BoostEffect()
    {
        player.GetComponent<PlayerController>().playerSpeed = player.GetComponent<PlayerController>().playerSpeed * boostAmount;
        Invoke("ResetBoost", boostLength);
    }

    private void ResetBoost()
    {
        player.GetComponent<PlayerController>().playerSpeed = player.GetComponent<PlayerController>().playerSpeed / boostAmount;
    }


    public bool IsPlayerInRange()
    {
        return Vector3.Distance(transform.position, player.transform.position) <= 1.5;
    }


}
