using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalGeneration : MonoBehaviour
{
   
    public Transform[] goalPositions;
    public GameObject teleporter;


    void Start()
    {
       

        int randGoalPos = Random.Range(0, goalPositions.Length);
        transform.position = goalPositions[randGoalPos].position;
        Instantiate(teleporter, transform.position, Quaternion.identity);


    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
