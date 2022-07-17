using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject boss;
    public GameObject player;
    private GameObject newBoss;
    private SpriteRenderer rend;
    private int randomSpawnZone;
    private float randomXposition, randomYposition;
    private Vector3 spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBoss", 0f, 1f);
    }

    private void SpawnBoss()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        if (Counters.killCount == 10)
        {
            spawnPosition = player.transform.position + new Vector3(3f, 3f, 0f);
            newBoss = Instantiate(boss, spawnPosition, Quaternion.identity);
            rend = newBoss.GetComponent<SpriteRenderer>();
            Counters.killCount -= 10;
        }
    }
}
