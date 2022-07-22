using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum WagonState
{
    Wander,
    Follow,
    Attack,
    Die
};


public class WagonController : MonoBehaviour
{
    public static WagonController instance;
    LootScript loot;
    public GameObject target;
    
 
  


    public WagonState currState = WagonState.Follow;
    //private bool chooseDir = false;
    private Vector2 randomDir;
   // private bool coolDownAttack = false;
    public bool holdWagon;

    public float range = 10f;
    public float speed = 3f;
    //public float currentHealth;
    //public float maxHealth;
    public float attackRange = 1.2f;
    //public float coolDown;
    //public float attackDamage;



    // Start is called before the first frame update
    void Start()
    {
      
     
  



    }




    // Update is called once per frame
    void Update()
    {
       // if (currState == WagonState.Wander)
        //{
         //   Wander();
        //}
        if (currState == WagonState.Follow && holdWagon == false)
        {
            Follow();
        }
        //else if (currState == WagonState.Die)
       // {
        //    Death();
       // }
        else if (currState == WagonState.Attack)
        {
            Attack();
        }



        if (IsPlayerInRange(range))
        {
            currState = WagonState.Follow;
        }
        //else if (!IsPlayerInRange(range) && currState != WagonState.Die)
        //{
         //   currState = WagonState.Wander;
       // }
        // attack player
        if (Vector3.Distance(transform.position, target.transform.position) <= attackRange)
        {
            holdWagon = true;
        }
        else
        {
            holdWagon = false;
        }
    }

    private bool IsPlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, target.transform.position) <= range;
    }
    private IEnumerator ChooseDirection()
    {
        //chooseDir = true;
        yield return new WaitForSeconds(Random.Range(2f, 8f));
        randomDir = new Vector2(0, Random.Range(0, 360));
        Quaternion nextRotation = Quaternion.Euler(randomDir);
        //transform.rotation = Quaternion.Lerp(transform.rotation, nextRotation, Random.Range(0.5f, 2.5f));
        //chooseDir = false;
    }
   // void Wander()
    //{
     //   if (!chooseDir)
      //  {
       //     StartCoroutine(ChooseDirection());
        //}

        //transform.position += -transform.right * speed * Time.deltaTime;
        //if (IsPlayerInRange(range))
        //{
         //   currState = WagonState.Follow;
        //}

    //}

    void Attack()
    {
        //if (!coolDownAttack)
       // {
         //   player.GetComponent<PlayerController>().TakeDamage(attackDamage);
        //    StartCoroutine(CoolDown());
       // }

    }
    //IEnumerator CoolDown()
    //{
        //coolDownAttack = true;
        //yield return new WaitForSeconds(coolDown);
        //coolDownAttack = false;
   // }
    void Follow()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
  
   
}
