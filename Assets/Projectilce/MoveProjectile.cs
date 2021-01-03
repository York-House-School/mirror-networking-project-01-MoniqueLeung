using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

//Script by Monique Leung November-December2020 for Computer Programming 12 G Project Name = EXHILE

public class MoveProjectile : NetworkBehaviour
{

  public float speed;
  public float fireRate;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if (speed != 0)
      {
        transform.position += transform.forward * (speed * Time.deltaTime);
      }
      else
      {
        Debug.Log("No Speed");
      }
    }
}
