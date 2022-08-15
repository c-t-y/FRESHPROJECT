using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveController : MonoBehaviour
{
    public WaveScript[] waves;

    private WaveScript currentWave;

    [SerializeField]
    private Transform[] spawnpoints;
    private float timeBtwnSpawns;
    private int i = 0;
    public bool isInBounds;
    public GameObject waveTextGameObject;
    public TextMeshProUGUI waveText;

    private bool stopSpawning = false;

    private void Awake()
    {

        currentWave = waves[i];
        timeBtwnSpawns = currentWave.TimeBeforeThisWave;

    }
    private void Start()
    {

    }

    private void Update()
    {




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
        WaveTextOverlay();
        for (int i = 0; i < currentWave.NumberToSpawn; i++)
        {

            int num = Random.Range(0, currentWave.EnemiesInWave.Length);
            int num2 = Random.Range(0, spawnpoints.Length);
            if (spawnpoints[num2].GetComponent<BoundsChecker>().isInBounds)
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

    private void WaveTextOverlay()
    {
        waveTextGameObject.SetActive(true);
        waveText.text = "Wave " + (i + 1).ToString();
        StartCoroutine(ShowWaveText());
    }
    IEnumerator ShowWaveText()
    {

        yield return new WaitForSeconds(3);
        waveTextGameObject.SetActive(false);
    }
}
