using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerScript5 : NetworkBehaviour
{


  public Rigidbody rb;
  public Animator anim;
  public CharacterController controller;
  public Camera camera;

  public float speed;
  public float turnspeed;
  public float MouseSensitivity;


  //private Vector3 moveDirection = Vector3.zero;

  public KeyCode forward;
  public KeyCode backwards;
  public KeyCode right;
  public KeyCode left;
  public KeyCode up;
  public KeyCode down;

    // Start is called before the first frame update
    void Start()
    {
      controller = GetComponent <CharacterController>();
			anim = gameObject.GetComponentInChildren<Animator>();
			rb = GetComponent <Rigidbody>();

    }


void MomoPlayerMovement(){

  if(isLocalPlayer){
    rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * MouseSensitivity, 0)));
    rb.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * speed ) + (transform.right * Input.GetAxis("Horizontal") * speed ));
    if (Input.GetKey(KeyCode.E))
    {
        rb.MovePosition(transform.position + Vector3.up * speed );
    }
    if (Input.GetKey(KeyCode.Q))
    {
        rb.MovePosition(transform.position + Vector3.down * speed);
    }
  }



}

    // Update is called once per frame
    void Update()
    {
      MomoPlayerMovement();
    }
}
