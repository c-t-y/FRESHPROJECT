using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsInterest : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject[] pointsInterest;


    void Start()
    {
       
        for (int i = 0; i < pointsInterest.Length; ++i)
        {
            int randIndex = Random.Range(0, spawnPoints.Length);
            GameObject sp = spawnPoints[randIndex];
           

            Instantiate(pointsInterest[i], sp.transform.position, Quaternion.identity);
        }
    }



}



