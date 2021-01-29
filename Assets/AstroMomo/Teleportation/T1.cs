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
      //the public transform allows for the player to be teleported
      public Transform teleportTarget;
      public GameObject astroboiiPlayer;
      // Start is called before the first frame update
      //This void Start here is actually uneeded due to the fact that start doesn't do anything in this script.
      void Start()
      {

      }
      // Update is called once per frame
      void Update()
      {

      }
      //The reason why this is a OnTriggerEnter command here is because once the player comes in contact with
      //the collider of the teleportation platform than this void will run instantly.
      void OnTriggerEnter(Collider other)
      {
        astroboiiPlayer.transform.position = teleportTarget.transform.position;
      }
      //this line transforms the players position from one teleportation platform to the next.

  } //public class last bracket
} //namespace bracket
