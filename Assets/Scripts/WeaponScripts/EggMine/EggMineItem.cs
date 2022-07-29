using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggMineItem : MonoBehaviour
{
    GameObject player;
    WeaponController playerWeaponController;
    GameObject text;
    public int cost;
    public GameObject eggMine;
    public float mineSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        mineSpawnTime = 5f;
        cost = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        playerWeaponController = player.GetComponent<WeaponController>();
        text = transform.GetChild(0).gameObject;

        StartCoroutine(ApplyItemEffect());
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlayerInRange())
        {
            text.SetActive(true);
        }
        else
        {
            text.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.E) && IsPlayerInRange() && GameManager.coinCount >= cost)
        {
           
            GameManager.coinCount -= cost;
            Destroy(gameObject);
        }
    }
    public bool IsPlayerInRange()
    {
        return Vector3.Distance(transform.position, player.transform.position) <= 1.5;
    }
    public IEnumerator ApplyItemEffect()
    {
        yield return new WaitForSeconds(.01f);
        Instantiate(eggMine, player.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(mineSpawnTime);
    }
}