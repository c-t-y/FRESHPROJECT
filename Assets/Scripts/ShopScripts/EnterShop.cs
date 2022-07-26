using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterShop : MonoBehaviour
{
    public GameObject player;
    public GameObject crossfader;
    public GameObject playerSpawnMarker;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerSpawnMarker = GameObject.FindGameObjectWithTag("ShopSpawnMarker");
        crossfader = GameObject.FindGameObjectWithTag("Transition");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            Debug.Log("test");
            StartCoroutine(GoToShop());
        }
    }

    IEnumerator GoToShop()
    {
        //crossfader.SetActive(true);
        crossfader.GetComponent<Animator>().SetBool("shouldAnimate", true);
        Debug.Log("waitttt");

        yield return new WaitForSeconds(0.5f);
        player.transform.position = playerSpawnMarker.transform.position;



        yield return new WaitForSeconds(0.5f);
        Debug.Log("wow");
        crossfader.GetComponent<Animator>().SetBool("shouldAnimate", false);
        //crossfader.SetActive(false);
    }

}
