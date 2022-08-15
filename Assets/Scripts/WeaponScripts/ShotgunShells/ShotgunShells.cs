using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunShells : MonoBehaviour
{
    GameObject player;

    public GameObject itemStorage;

    public bool text;
    public int cost;
    public float bulletSpread;
    public float shotCoolDown;
    public bool itemGrabbed;
    public GameObject bulletPrefab;
    //public Animator animator;
    public bool allowFire;
    public float shotgunCap;
    public float bulletSpeed;


    // Start is called before the first frame update
    void Start()
    {
      
        itemStorage = GameObject.FindGameObjectWithTag("ItemStorage");
        shotCoolDown = 1f;
        cost = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        itemGrabbed = false;
        text = false;
        bulletSpeed = 100f;
        bulletSpread = .5f;
        allowFire = true;
        shotgunCap = 3f;

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

        //shooting input

        if (itemGrabbed == true)
        {
            if (Input.GetKey(KeyCode.UpArrow) && allowFire == true)
            {

                ShootShotgun("up");

                allowFire = false;
                StartCoroutine(FireCooldown());

            }
            if (Input.GetKey(KeyCode.DownArrow) && allowFire == true)
            {
                ShootShotgun("down");
                allowFire = false;
                StartCoroutine(FireCooldown());

            }
            if (Input.GetKey(KeyCode.LeftArrow) && allowFire == true)
            {
                ShootShotgun("left");
                allowFire = false;
                StartCoroutine(FireCooldown());

            }
            if (Input.GetKey(KeyCode.RightArrow) && allowFire == true)
            {
                ShootShotgun("right");
                allowFire = false;
                StartCoroutine(FireCooldown());
            }
        }

    }


    public bool IsPlayerInRange()
    {
        return Vector3.Distance(transform.position, player.transform.position) <= 1.5;
    }


    void ShootShotgun(string direction)
    {
        for (int i = 0; i < shotgunCap; i++)
        {
            float randBullet = Random.Range(-bulletSpread, bulletSpread);

            if (direction == "up")
            {

                var bulletInstance = Instantiate(bulletPrefab, new Vector3(player.transform.position.x + randBullet, player.transform.position.y, -1), Quaternion.identity);
                bulletInstance.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 1, 0) * bulletSpeed);
            }
            if (direction == "down")
            {
                var bulletInstance = Instantiate(bulletPrefab, new Vector3(player.transform.position.x + randBullet, player.transform.position.y, -1), Quaternion.identity);
                bulletInstance.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, -1, 0) * bulletSpeed);
            }
            if (direction == "left")
            {

                var bulletInstance = Instantiate(bulletPrefab, new Vector3(player.transform.position.x, player.transform.position.y + randBullet, -1), Quaternion.identity);
                bulletInstance.GetComponent<Rigidbody2D>().AddForce(new Vector3(-1, 0, 0) * bulletSpeed);


            }
            if (direction == "right")
            {

                var bulletInstance = Instantiate(bulletPrefab, new Vector3(player.transform.position.x, player.transform.position.y + randBullet, -1), Quaternion.identity);
                bulletInstance.GetComponent<Rigidbody2D>().AddForce(new Vector3(1, 0, 0) * bulletSpeed);

            }
        }

    }
    public IEnumerator FireCooldown()
    {
        yield return new WaitForSeconds(shotCoolDown);

        allowFire = true;
    }



}