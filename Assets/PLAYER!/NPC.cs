using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

//Script by Monique Leung November-December2020 for Computer Programming 12 G Project Name = EXHILE

public class NPC : NetworkBehaviour
{

    public GameObject ThePlayer;
    public float TargetDistance;
    public float AllowedDistance = 1;
    public GameObject TheNPC;
    public float FollowSpeed;
    public RaycastHit Shot;

    void Update()
    {
      transform.LookAt(ThePlayer.transform);
      if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out Shot))
      {
        TargetDistance = Shot.distance;
        if(TargetDistance >= AllowedDistance)
        {
          FollowSpeed = 30f;
          TheNPC.GetComponent<Animation>().Play("Walking");
          transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, FollowSpeed);
        }
        else
        {
          FollowSpeed = 0;
          TheNPC.GetComponent<Animation>().Play("Idle");
        }
      }
    }
}
