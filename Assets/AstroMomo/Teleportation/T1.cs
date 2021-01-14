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
      public Transform teleportTarget;
      public GameObject astroboiiPlayer;
      // Start is called before the first frame update
      void Start()
      {

      }

      // Update is called once per frame
      void Update()
      {

      }

      void OnTriggerEnter(Collider other)
      {
        astroboiiPlayer.transform.position = teleportTarget.transform.position;
      }

  } //public class last bracket
} //namespace bracket
