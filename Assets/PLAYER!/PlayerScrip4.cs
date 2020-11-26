using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

//Script by Monique Leung November-December2020 for Computer Programming 12 G Project Name = EXHILE
public class PlayerScrip4 : NetworkBehaviour
{

  //public Animator anim;
  //public CharacterController controller;
  //public Camera playerCamera;
//  public Rigidbody rb;

  //the following variables are for the input HandleError




    // Start is called before the first frame update
  //  void Start()
  //  {
  //    controller = GetComponent <CharacterController>();
  //    anim = gameObject.GetComponentInChildren<Animator>();
//      rb = GetComponent <Rigidbody>();
//    }

//    void CharacterMovementMethod()
//    {

  				// horizontal character rotation
//  				{
  						// rotate the transform with the input speed around its local Y axis
//  						transform.Rotate(new Vector3(0f, (m_InputHandler.GetLookInputsHorizontal() * rotationSpeed * RotationMultiplier), 0f), Space.Self);
//  				}

  				// vertical camera rotation
//  				{
  						// add vertical inputs to the camera's vertical angle
//  						m_CameraVerticalAngle += m_InputHandler.GetLookInputsVertical() * rotationSpeed * RotationMultiplier;

  						// limit the camera's vertical angle to min/max
//  						m_CameraVerticalAngle = Mathf.Clamp(m_CameraVerticalAngle, -89f, 89f);
//
  						// apply the vertical angle as a local rotation to the camera transform along its right axis (makes it pivot up and down)
//  						playerCamera.transform.localEulerAngles = new Vector3(m_CameraVerticalAngle, 0, 0);
//  				}
//    }



    // Update is called once per frame
//    void Update()
//    {
//      CharacterMovementMethod();
//    }

}
