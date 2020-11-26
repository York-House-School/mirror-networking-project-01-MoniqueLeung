using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

//Script by Monique Leung November-December2020 for Computer Programming 12 G, Project Name = EXHILE

public class ConstantRotation : NetworkBehaviour
{
    [Tooltip("Rotation angle per second")]
    public float rotatingSpeed = 360f;

    void Update()
    {
        // Handle rotating
        transform.Rotate(Vector3.up, rotatingSpeed * Time.deltaTime, Space.Self);
    }
}
