using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

//Script by Monique Leung November-December2020 for Computer Programming 12 G Project Name = EXHILE

public class SpawnProjectile : NetworkBehaviour
{
  public GameObject firepoint;
  public List<GameObject> vfx = new List<GameObject> ();

  private GameObject effectToSpawn;
  //public KeyCode FIRE;
    // Start is called before the first frame update
    void Start()
    {
      effectToSpawn = vfx[0];
    }

    // Update is called once per frame
    void Update()
    {
      //if(isLocalPlayer)
    //  {
        if(Input.GetMouseButton(0))
        {
          SpawnVFX();
        }
    //  }

    }

    void SpawnVFX()
    {
      GameObject vfx;


      if(firepoint != null)
      {
          vfx = Instantiate (effectToSpawn, firepoint.transform.position, Quaternion.identity);
      }

      else
      {
          Debug.Log ("No Fire Point");
      }


    }



}
