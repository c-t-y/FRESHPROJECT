using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour
{

    GameObject player;
    public float spawnRate = 3f;
    //public float spawnIncrease = 1f;
    public float spawnBlockDistance;
    public float spawnMaxDistance;
    private float spawnspace;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        

        spawnRate = 3f;
        spawnBlockDistance = 10f;
        spawnMaxDistance = 22f;

        //StartCoroutine(SpawnTimer());
        InvokeRepeating("CalculateSpawn", 3f, spawnRate);
        InvokeRepeating("IncreaseEnemySpawn", 0f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        spawnspace = Vector3.Distance(transform.position, player.transform.position);

        if (spawnspace >= spawnBlockDistance && spawnspace <= spawnMaxDistance)
        {
            spawnChance = 100f;
        }
        else
        {
            spawnChance = 0f;
        }
    }

    public void IncreaseEnemySpawn()
    {
        spawnRate *= 0.5f;
        Debug.Log("spawn rate increased");
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

    //public IEnumerator SpawnTimer()
    //{
     //   CalculateSpawn();
      //  yield return new WaitForSeconds(spawnRate);
        
    //}

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
