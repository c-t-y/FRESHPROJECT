using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject[] objects;


    void Start()
    {
        int rand = Random.Range(0, objects.Length);
        var roomObject = Instantiate(objects[rand], transform.position, Quaternion.identity);
        roomObject.transform.SetParent(gameObject.transform);
    }

  
}
