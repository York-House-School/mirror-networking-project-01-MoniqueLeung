using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

//Script by Monique Leung November-December2020 for Computer Programming 12 G Project Name = EXHILE

public class PlayerOriginal : NetworkBehaviour
{
    // Start is called before the first frame update
    void HandleMovement()
    {
      if (isLocalPlayer){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal*0.1f, moveVertical*0.1f,0);
        transform.position = transform.position + movement;
      }
    }

    // Update is called once per frame
    void Update()
    {
      HandleMovement();
    }
}
