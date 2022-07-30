using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalmonellaItem : MonoBehaviour
{
    GameObject player;

    public bool text;
    public int cost;
    public GameObject salmonellaShot;
    public float salmonellaCoolDown;
    public bool itemGrabbed;

    public GameObject salmonellaPrefab;
    public Animator animator;
    public bool allowFire;
    public float bulletSpread = 0f;
    public float bulletSpeed;
    public float fireRate;

    // Start is called before the first frame update
    void Start()
    {
        salmonellaCoolDown = 10f;
        cost = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        itemGrabbed = false;
        text = false;

        allowFire = true;

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
            ActivateItem();
            GameManager.coinCount -= cost;
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.parent = player.transform;

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

    public void ActivateItem()
    {
        if (itemGrabbed == true)
        {
            InvokeRepeating("ApplyItemEffect", 3f, 3f);
        }
    }
    public void ApplyItemEffect()
    {

     

    }
    void ShootSalmonella(string direction)
    {
        float randBullet = Random.Range(-bulletSpread, bulletSpread);

        if (direction == "up")
        {

            var bulletInstance = Instantiate(salmonellaPrefab, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody2D>().AddForce(new Vector3(randBullet, 1, 0) * bulletSpeed);
        }
        if (direction == "down")
        {
            var bulletInstance = Instantiate(salmonellaPrefab, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody2D>().AddForce(new Vector3(randBullet, -1, 0) * bulletSpeed);
        }
        if (direction == "left")
        {
            animator.SetBool("ShootLeft", true);
            var bulletInstance = Instantiate(salmonellaPrefab, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody2D>().AddForce(new Vector3(-1, randBullet, 0) * bulletSpeed);


        }
        if (direction == "right")
        {
            animator.SetBool("ShootRight", true);
            var bulletInstance = Instantiate(salmonellaPrefab, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody2D>().AddForce(new Vector3(1, randBullet, 0) * bulletSpeed);

        }
    }
    public IEnumerator FireCooldown()
    {
        yield return new WaitForSeconds(salmonellaCoolDown);
        animator.SetBool("ShootLeft", false);
        animator.SetBool("ShootRight", false);
        allowFire = true;
    }



}
