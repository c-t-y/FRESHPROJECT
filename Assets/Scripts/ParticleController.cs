using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(DestoryParticleAfterTime());
    }




    IEnumerator DestoryParticleAfterTime()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
