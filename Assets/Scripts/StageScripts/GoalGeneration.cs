using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalGeneration : MonoBehaviour
{
   //placeholder merchant for testing, can make a wandering or traveling salesman later
    public Transform[] goalPositions;
    public GameObject teleporter;
    public GameObject merchant;
    public GameObject casino;

    //create teleporter and then other points of interest
    void Start()
    {
       
        //select starting spawn point used for teleporter
        int randGoalPos = Random.Range(0, goalPositions.Length);
        
        
        teleporter.transform.position = goalPositions[randGoalPos].position;
        Instantiate(teleporter, teleporter.transform.position, Quaternion.identity);

        //select merchant position
        if (randGoalPos > 5)
        {
            merchant.transform.position = goalPositions[0].position;
            Instantiate(merchant, merchant.transform.position, Quaternion.identity);
        }
        else 
        {
            merchant.transform.position = goalPositions[randGoalPos + 2].position;
            Instantiate(merchant, merchant.transform.position, Quaternion.identity);
        }

        //select casino position
       if (randGoalPos < 3)
        {
            casino.transform.position = goalPositions[6].position;
            Instantiate(casino, casino.transform.position, Quaternion.identity);
        }
        else
        {
            casino.transform.position = goalPositions[randGoalPos - 3].position;
            Instantiate(casino, casino.transform.position, Quaternion.identity);
        }


    }


    
}
