using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public WaveScript[] waves;

    private WaveScript currentWave;

    [SerializeField]
    private Transform[] spawnpoints;
    private float timeBtwnSpawns;
    private int i = 0;
    private bool isInBounds;
    public GameObject topBounds;
    public GameObject leftBounds;
    public GameObject rightBounds;
    public GameObject bottomBounds;

    private bool stopSpawning = false;

    private void Awake()
    {
        currentWave = waves[i];
        timeBtwnSpawns = currentWave.TimeBeforeThisWave;
        isInBounds = true;

    }

    private void Start()
    {
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
            isInBounds = true;
        }
        else
        {
            isInBounds = false;
        }


        if (stopSpawning)
        {
            return;
        }


        if (Time.time >= timeBtwnSpawns)
        {
            SpawnWave();
            IncWave();

            timeBtwnSpawns = Time.time + currentWave.TimeBeforeThisWave;
        }
    }

    private void SpawnWave()
    {
        for (int i = 0; i < currentWave.NumberToSpawn; i++)
        {
            int num = Random.Range(0, currentWave.EnemiesInWave.Length);
            int num2 = Random.Range(0, spawnpoints.Length);
            if (isInBounds == true)
            {
                Instantiate(currentWave.EnemiesInWave[num], spawnpoints[num2].position, Quaternion.identity);
            }


        }
    }

    private void IncWave()
    {
        if (i + 1 < waves.Length)
        {
            i++;
            currentWave = waves[i];
        }
        else
        {
            stopSpawning = true;
        }
    }
}
