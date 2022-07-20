using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    public GameObject player;
    private GameObject newEnemy;
    private SpriteRenderer rend;
    private int randomSpawnZone;
    private float randomXposition, randomYposition;
    private Vector3 spawnPosition;
    public float spawnRate = 1f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnNewEnemy", 0f, spawnRate);
    }

    private void SpawnNewEnemy()
    {
        randomSpawnZone = Random.Range(0, 4);

        switch (randomSpawnZone)
        {
            case 0:
                randomXposition = Random.Range(-11f, -11f);
                randomYposition = Random.Range(-11f, -11f);
                break;
            case 1:
                randomXposition = Random.Range(-11f, 11f);
                randomYposition = Random.Range(-11f, -11f);
                break;
            case 2:
                randomXposition = Random.Range(11f, 11f);
                randomYposition = Random.Range(-11f, 11f);
                break;
            case 3:
                randomXposition = Random.Range(-11f, 11f);
                randomYposition = Random.Range(11f, 11f);
                break;
            case 4:
                randomXposition = Random.Range(11f, 11f);
                randomYposition = Random.Range(11f, 11f);
                break;
        }
        spawnPosition = player.transform.position + new Vector3(randomXposition, randomYposition, 0f);
        newEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
        rend = newEnemy.GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
