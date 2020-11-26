﻿using UnityEngine;
using Mirror;

//Script by Monique Leung November-December2020 for Computer Programming 12 G, Project Name = EXHILE

// Component used to override values on start from the NavmeshAgent component in order to change
// how the agent  is moving
public class NavigationModule : NetworkBehaviour
{
    [Header("Parameters")]
    [Tooltip("The maximum speed at which the enemy is moving (in world units per second).")]
    public float moveSpeed = 0f;
    [Tooltip("The maximum speed at which the enemy is rotating (degrees per second).")]
    public float angularSpeed = 0f;
    [Tooltip("The acceleration to reach the maximum speed (in world units per second squared).")]
    public float acceleration = 0f;
}
