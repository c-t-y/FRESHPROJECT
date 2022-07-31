using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RazorFeatherItem : MonoBehaviour
{

    public GameObject player;
    private PlayerController access;
    public GameObject itemStorage;
    public float razorCoolDown;
    public bool text;
    public int cost;
    public bool itemGrabbed;
    public bool allowRazor;
    public float playerHealthOriginal;
    public float playerHealthUpdate;

    public GameObject razorObject;
    //public Animator animator;
  

    // Start is called before the first frame update
    void Start()
    {
        allowRazor = true;
        razorCoolDown = 25f;
        cost = 0;
        itemStorage = GameObject.FindGameObjectWithTag("ItemStorage");
        player = GameObject.FindGameObjectWithTag("Player");
        itemGrabbed = false;
        text = false;
        access = player.GetComponent<PlayerController>();
        

    }

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
            gameObject.transform.position = new Vector3(itemStorage.transform.position.x + GameManager.itemsGrabbed, itemStorage.transform.position.y, -4);
            PlayerHealthCheck();
        }
        
        //checking for player damage to trigger razorfeathers
        playerHealthUpdate = access.currentHealth;
        
        if(playerHealthUpdate < playerHealthOriginal)
        {
            CreateRazor();
            playerHealthOriginal = playerHealthUpdate;
        }
        if(playerHealthUpdate > playerHealthOriginal)
        {
            playerHealthOriginal = playerHealthUpdate;
        }

    }

    private void PlayerHealthCheck()
    {
        playerHealthOriginal = access.currentHealth;

    }
    public bool IsPlayerInRange()
    {
        return Vector3.Distance(transform.position, player.transform.position) <= 1.5;
    }

    public IEnumerator RazorCooldown()
    {
        yield return new WaitForSeconds(.1f);
        allowRazor = false;

        yield return new WaitForSeconds(razorCoolDown);
        allowRazor = true;
    }

    public void CreateRazor()
    {
        if (allowRazor == true && itemGrabbed == true)
        {
            Instantiate(razorObject, player.transform.position, Quaternion.identity);
            StartCoroutine(RazorCooldown());
        }
    }

}