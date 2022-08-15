using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageIndicator : MonoBehaviour
{
    private Pooler pool;
    public GameObject player;
    public TMP_Text damageText;
    // Start is called before the first frame update
    void Start()
    {
        pool = transform.parent.GetComponent<Pooler>();
        player = GameObject.FindGameObjectWithTag("Player");
        damageText.text = player.GetComponent<PlayerController>().calcPlayerDamage.ToString();
        transform.localPosition += new Vector3(0, 1f, 0);

    }

    private void OnEnable()
    {
        StartCoroutine(DestoryIndicatorAfterTime());
    }
    IEnumerator DestoryIndicatorAfterTime()
    {
        yield return new WaitForSeconds(1f);
        pool.ReturnObject(gameObject);
    }
}
