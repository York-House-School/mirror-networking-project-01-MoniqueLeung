using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Mirror;

//Script by Monique Leung November-January2020 for Computer Programming 12 G Project Name = EXHILE
namespace AstroMomo
{
  public class T1 : NetworkBehaviour
  {
      
      void Start()
      {

      }
      void Update()
      {

      }
      //The reason why this is a OnTriggerEnter command here is because once the player comes in contact with
      //the collider of the teleportation platform than this void will run instantly.
      void OnTriggerEnter(Collider Col)
      {
        Col.transform.position = new Vector3(Random.Range(-10.0f,10.0f), Col.transform.position.y, Random.Range (-10.0f, 10.0f));
      }
      //this line transforms the players position to another random location

  } //public class last bracket
} //namespace bracket
