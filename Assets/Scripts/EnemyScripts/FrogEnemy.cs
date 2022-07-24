using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogEnemy : MonoBehaviour
{
    public GameObject player;
    public SpriteRenderer spriteRenderer;

    public static float eHealth = 100f;
    public static float eRange = 10f;
    public static float eSpeed = 1f;
    public static float eAttackDmg = 1f;
    public static float eAttackRng = 1f;
    public static float eAttackCD = 1f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        spriteRenderer.flipX = player.transform.position.x < transform.position.x;
    }
}


