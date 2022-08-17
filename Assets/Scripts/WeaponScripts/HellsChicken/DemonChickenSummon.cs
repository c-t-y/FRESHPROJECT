using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonChickenSummon : MonoBehaviour
{
 
    void Start()
    {
        StartCoroutine(DestroySummon());
    }

    public IEnumerator DestroySummon()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
