using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIncSpawner : MonoBehaviour
{
    GameObject player;
  
 
    public float spawnBlockDistance;
    public float spawnMaxDistance;
    private float spawnspace;
    public int maxEnemies;
    private int remainingEnemies;
    private bool allowSpawn;

    float delayAndSpawnRate = 3;
    float timeUntilSpawnRateIncrease = 5;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");



       
        spawnBlockDistance = 10f;
        spawnMaxDistance = 22f;
        maxEnemies = 200;

        StartCoroutine(SpawnObject(delayAndSpawnRate));
    }

    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        remainingEnemies = enemies.Length;

        if (remainingEnemies >= maxEnemies)
        {
            allowSpawn = false;
        }
        else
        {
            allowSpawn = true;
        }

        spawnspace = Vector3.Distance(transform.position, player.transform.position);



        if (spawnspace >= spawnBlockDistance && spawnspace <= spawnMaxDistance && allowSpawn == true)
        {
            spawnChance = 100f;
        }
        else
        {
            spawnChance = 20f;
        }
    }

    IEnumerator SpawnObject(float firstDelay)
    {
        float spawnRateCountdown = timeUntilSpawnRateIncrease;
        float spawnCountdown = firstDelay;
        while (true)
        {
            yield return null;
            spawnRateCountdown -= Time.deltaTime;
            spawnCountdown -= Time.deltaTime;

            // Should a new object be spawned?
            if (spawnCountdown < 0)
            {
                spawnCountdown += delayAndSpawnRate;
                CalculateSpawn();
            }

            // Should the spawn rate increase?
            if (spawnRateCountdown < 0 && delayAndSpawnRate > 1)
            {
                spawnRateCountdown += timeUntilSpawnRateIncrease;
                delayAndSpawnRate *= .75f;
            }
        }
    }

    [System.Serializable]
    public class SpawnEnemy
    {
        public string name;
        public GameObject enemy;
        public int spawnRarity;
    }

    public List<SpawnEnemy> SpawnTable = new List<SpawnEnemy>();
    public float spawnChance;

    public void CalculateSpawn()
    {
        float calc_dropChance = Random.Range(0, 101);

        if (calc_dropChance > spawnChance)
        {
            Debug.Log("No Spawn");
            return;

        }

        if (calc_dropChance <= spawnChance)
        {
            int spawnWeight = 0;

            for (int i = 0; i < SpawnTable.Count; i++)
            {
                spawnWeight += SpawnTable[i].spawnRarity;
            }

            int randomValue = Random.Range(0, spawnWeight);

            for (int j = 0; j < SpawnTable.Count; j++)
            {
                if (randomValue <= SpawnTable[j].spawnRarity)
                {
                    Instantiate(SpawnTable[j].enemy, transform.position, Quaternion.identity);
                    return;
                }
                randomValue -= SpawnTable[j].spawnRarity;
            }
        }

    }
}


