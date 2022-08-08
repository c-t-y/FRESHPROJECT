using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject[] rooms;



    void Start()
    {
        int rand = Random.Range(0, rooms.Length);
        var levelRooms = Instantiate(rooms[rand], transform.position, Quaternion.identity);
        levelRooms.transform.SetParent(gameObject.transform);


    }
   
}
