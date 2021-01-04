using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

//Script by Monique Leung November-December2020 for Computer Programming 12 G Project Name = EXHILE

public class spawnprojectile2 : NetworkBehaviour
{

  public GameObject firepoint;
  public List<GameObject> vfx = new List<GameObject>();

  private GameObject effectToSpawn;
    // Start is called before the first frame update
    void Start()
    {
      effectToSpawn = vfx[0];
    }

void SpawnVFX()
{


  GameObject vfx;

  if(Input.GetMouseButton(0))
  {
    vfx = Instantiate (effectToSpawn, firepoint.transform.position, Quaternion.identity);
  }
  else
  {
    Debug.Log ("No Fire Point");
  }
}
    // Update is called once per frame
    void Update()
    {
      if(Input.GetMouseButton(0))
      {
        SpawnVFX();
      }
      //SpawnVFX();
    }
}
