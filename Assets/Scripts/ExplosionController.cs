using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    private Pooler pool;

    private void Start()
    {
        pool = transform.parent.GetComponent<Pooler>();
    }
    private void OnEnable()
    {
        StartCoroutine(DestoryParticleAfterTime());
    }

    IEnumerator DestoryParticleAfterTime()
    {
        yield return new WaitForSeconds(1f);
        pool.ReturnObject(gameObject);
    }
}
