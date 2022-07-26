using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsInterest : MonoBehaviour
{

    public Transform[] roomPositions;
    public GameObject[] pointsInterest;


    void Start()
    {
        for (int i = 0; i < pointsInterest.Length; ++i)
        {
            int randRoomPos = Random.Range(0, roomPositions.Length);
            transform.position = roomPositions[randRoomPos].position;
            Instantiate(pointsInterest[i], transform.position, Quaternion.identity);
        }
    }


    void Update()
    {

    }
}