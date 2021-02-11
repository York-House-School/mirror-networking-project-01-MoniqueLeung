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

      void Start()
      {

      }
      public void OnTriggerEnter(Collider Col)
      {
        Col.transform.position = teleportTarget.transform.position;
        Debug.Log("teleportyeet");
      }
      
      
  } //public class last bracket
} //namespace bracket
