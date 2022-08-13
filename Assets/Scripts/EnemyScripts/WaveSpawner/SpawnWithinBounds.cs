using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWithinBounds : MonoBehaviour
{
    public GameObject topBounds;
    public GameObject leftBounds;
    public GameObject rightBounds;
    public GameObject bottomBounds;


    private void Start()
    {
        topBounds = GameObject.FindGameObjectWithTag("BoundsTop");
        leftBounds = GameObject.FindGameObjectWithTag("BoundsLeft");
        rightBounds = GameObject.FindGameObjectWithTag("BoundsRight");
        bottomBounds = GameObject.FindGameObjectWithTag("BoundsBottom");


    }
    private void Update()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (
                transform.GetChild(i).transform.position.y > topBounds.transform.position.y ||
                transform.GetChild(i).transform.position.y < bottomBounds.transform.position.y ||
                transform.GetChild(i).transform.position.x < leftBounds.transform.position.x ||
                transform.GetChild(i).transform.position.x > rightBounds.transform.position.x)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            else
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }

}
