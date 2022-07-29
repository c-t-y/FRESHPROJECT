using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    [Range(1, 10)]
    public float smoothFactor;

    // Update is called once per frame
    void FixedUpdate()
    {
        Follow();
    }
    void Follow()
    {
        Vector3 targetPosition = player.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}