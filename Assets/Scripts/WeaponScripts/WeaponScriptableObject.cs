using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Weapon Configuration", menuName = "ScriptableObject/Weapon Configuration")]
public class WeaponScriptableObject : ScriptableObject
{
    public string gunName;
    public float gunDmg;
    public float gunFireRate;
    public float gunShotSpeed;

}
