using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsChecker : MonoBehaviour
{
    public GameObject topBounds;
    public GameObject leftBounds;
    public GameObject rightBounds;
    public GameObject bottomBounds;
    public bool isInBounds;


    private void Start()
    {
        isInBounds = true;
        topBounds = GameObject.FindGameObjectWithTag("BoundsTop");
        leftBounds = GameObject.FindGameObjectWithTag("BoundsLeft");
        rightBounds = GameObject.FindGameObjectWithTag("BoundsRight");
        bottomBounds = GameObject.FindGameObjectWithTag("BoundsBottom");


    }
    private void Update()
    {

        if (
            transform.position.y > topBounds.transform.position.y ||
           transform.position.y < bottomBounds.transform.position.y ||
            transform.position.x < leftBounds.transform.position.x ||
            transform.position.x > rightBounds.transform.position.x)
        {
            isInBounds = false;
        }
        else
        {
            isInBounds = true;
        }
    }

}
