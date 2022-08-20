using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalmonellaItem : MonoBehaviour
{
    GameObject player;
    public GameObject itemStorage;

    public bool text;
    public int cost;

    public float salmonellaCoolDown;
    public bool itemGrabbed;

    public GameObject salmonellaPrefab;
    //public Animator animator;
    public bool allowFire;
  
    public float bulletSpeed;

    private Vector2 itemMove1;
    private Vector2 itemMove2;
    public float itemSpeed;


    // Start is called before the first frame update
    void Start()
    {
        salmonellaCoolDown = 5f;
        cost = 0;
        itemStorage = GameObject.FindGameObjectWithTag("ItemStorage");
        player = GameObject.FindGameObjectWithTag("Player");
        itemGrabbed = false;
        text = false;
        bulletSpeed = 100f;

        allowFire = true;
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

        //shooting input

        if (itemGrabbed == true)
        {
            if (Input.GetKey(KeyCode.UpArrow) && allowFire == true)
            {
                ShootSalmonella("up");
                allowFire = false;
                StartCoroutine(FireCooldown());

            }
            if (Input.GetKey(KeyCode.DownArrow) && allowFire == true)
            {
                ShootSalmonella("down");
                allowFire = false;
                StartCoroutine(FireCooldown());

            }
            if (Input.GetKey(KeyCode.LeftArrow) && allowFire == true)
            {
                ShootSalmonella("left");
                allowFire = false;
                StartCoroutine(FireCooldown());

            }
            if (Input.GetKey(KeyCode.RightArrow) && allowFire == true)
            {
                ShootSalmonella("right");
                allowFire = false;
                StartCoroutine(FireCooldown());
            }
        }

    }


    public bool IsPlayerInRange()
    {
        return Vector3.Distance(transform.position, player.transform.position) <= 1.5;
    }


    void ShootSalmonella(string direction)
    {
        //float randBullet = Random.Range(-bulletSpread, bulletSpread);

        if (direction == "up")
        {

            var bulletInstance = Instantiate(salmonellaPrefab, new Vector3(player.transform.position.x, player.transform.position.y, -1), Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 1, 0) * bulletSpeed);
        }
        if (direction == "down")
        {
            var bulletInstance = Instantiate(salmonellaPrefab, new Vector3(player.transform.position.x, player.transform.position.y, -1), Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, -1, 0) * bulletSpeed);
        }
        if (direction == "left")
        {
            
            var bulletInstance = Instantiate(salmonellaPrefab, new Vector3(player.transform.position.x, player.transform.position.y, -1), Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody2D>().AddForce(new Vector3(-1, 0, 0) * bulletSpeed);


        }
        if (direction == "right")
        {
           
            var bulletInstance = Instantiate(salmonellaPrefab, new Vector3(player.transform.position.x, player.transform.position.y, -1), Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody2D>().AddForce(new Vector3(1, 0, 0) * bulletSpeed);

        }
    }
    public IEnumerator FireCooldown()
    {
        yield return new WaitForSeconds(salmonellaCoolDown);
       
        allowFire = true;
    }



}
