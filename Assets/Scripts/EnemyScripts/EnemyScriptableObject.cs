using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Enemy Configuration", menuName = "ScriptableObject/Enemy Configuration")]
public class EnemyScriptableObject : ScriptableObject
{
    public float eHealth = 200f;
    public float eRange = 10f;
    public float eSpeed = 1f;
    public float eAttackDmg = 1f;
    public float eAttackRng = 1f;
    public float eAttackCD = 1f;
}
