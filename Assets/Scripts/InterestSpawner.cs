using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterestSpawner : MonoBehaviour
{
    public Transform[] spawns;
    public GameObject[] objects;
    

    void Update()
    {
        Spawn(objects, spawns);
    }

    void Spawn(GameObject[] gameObjects, Transform[] locations, bool allowOverlap = true )
    {
        List<GameObject> remainingGameObjects = new List<GameObject>(gameObjects);
        List<Transform> freeLocations = new List<Transform>(locations);

        if (locations.Length < gameObjects.Length)
            Debug.LogWarning(allowOverlap);

        while(remainingGameObjects.Count > 0)
        {
            if(freeLocations.Count == 0)
            {
                if (allowOverlap) freeLocations.AddRange(locations);
                else break;
            }

            int gameObjectIndex = Random.Range(0, remainingGameObjects.Count);
            int locationIndex = Random.Range(0, freeLocations.Count);
            Instantiate(gameObjects[gameObjectIndex], locations[locationIndex].position, Quaternion.identity);
            remainingGameObjects.RemoveAt(gameObjectIndex);
            freeLocations.RemoveAt(locationIndex);

        }

    }


}
