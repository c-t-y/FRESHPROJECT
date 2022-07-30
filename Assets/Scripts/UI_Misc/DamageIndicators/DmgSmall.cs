using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DmgSmall : MonoBehaviour
{
    public GameObject player;
    public TMP_Text damageText;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        damageText.text = player.GetComponent<PlayerController>().calcPlayerDamageSmall.ToString();
        Destroy(gameObject, 1f);
        transform.localPosition += new Vector3(0, 1f, 0);

    }
}
