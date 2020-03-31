using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 targetPosition;
    private Vector3 currentVelocity;

    public float viewPortFactor;
    public float followDurration;
    public float maximumFollowSpeed;
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        targetPosition = player.position - new Vector3(0, 0, 10);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, followDurration, maximumFollowSpeed);
    }
}
