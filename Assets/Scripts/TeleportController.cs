using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player" && GameManager.killCount >= 3)
        {
            Destroy(gameObject);

        }

        


    }

}
