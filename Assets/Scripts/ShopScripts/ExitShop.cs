using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitShop : MonoBehaviour
{
    public GameObject player;
    public Animator transition;
    public GameObject crossfader;
    public GameObject shopSpawnMarker;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            Debug.Log("test");
            StartCoroutine(LeaveShop());
        }
    }

    IEnumerator LeaveShop()
    {
        //crossfader.SetActive(true);
        crossfader.GetComponent<Animator>().SetBool("shouldAnimate", true);
        Debug.Log("waitttt");

        yield return new WaitForSeconds(0.5f);
        player.transform.position = new Vector3(shopSpawnMarker.transform.position.x, shopSpawnMarker.transform.position.y - 1, shopSpawnMarker.transform.position.z);

        yield return new WaitForSeconds(0.5f);
        Debug.Log("wow");
        //crossfader.SetActive(false);
        crossfader.GetComponent<Animator>().SetBool("shouldAnimate", false);
    }

}
