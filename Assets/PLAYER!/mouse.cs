using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

//Script by Monique Leung November-December2020 for Computer Programming 12 G, Project Name = EXHILE


public class mouse : NetworkBehaviour
{
  public float mouseSensitivity;
  public float mouseX,mouseY;
  public Transform playerBody;
  public float xRotation;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void MomoCameraMouseMovement()
    {
      if(isLocalPlayer)
            {

              float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
                      float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

                      xRotation -= mouseY;
                      xRotation = Mathf.Clamp(xRotation, -150f, 150f);
                      transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

                      playerBody.Rotate(Vector3.up * mouseX);
            }

    }

    void Update()

    {
      MomoCameraMouseMovement();
    }
}
