using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject[] rooms;
    //public GameObject[] goalPositions;
    //public GameObject teleporter;


    void Start()
    {
        int rand = Random.Range(0, rooms.Length);
        Instantiate(rooms[rand], transform.position, Quaternion.identity);

        //int randGoalPos = Random.Range(0,goalPositions.Length);
        //transform.position = goalPositions[randGoalPos].position; ".position" not working
        //Instantiate(teleporter, transform.position,Quaternion.identity);


    }


   

    // Update is called once per frame
    void Update()
    {
        
    }
}
