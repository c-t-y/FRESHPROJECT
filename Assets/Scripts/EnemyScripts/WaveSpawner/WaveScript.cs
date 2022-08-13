using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveScript", menuName = "ScriptableObject/Waves")]
public class WaveScript : ScriptableObject
{
    [field: SerializeField]

    public GameObject[] EnemiesInWave { get; private set; }
    [field: SerializeField]

    public float TimeBeforeThisWave { get; private set; }

    [field: SerializeField]
    public float NumberToSpawn { get; private set; }
}
