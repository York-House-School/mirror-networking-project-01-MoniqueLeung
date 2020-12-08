using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

//Script by Monique Leung November-December2020 for Computer Programming 12 G, Project Name = EXHILE

public class PlayerScript5 : NetworkBehaviour
{


  public float walkSpeed = 6.0F;
  public float jumpSpeed = 8.0F;
  public float runSpeed = 8.0F;
  public float gravity = 20.0F;

  private Vector3 moveDirection = Vector3.zero;
  /////////////////////////////

  public Rigidbody rb;
  public Animator anim;
  private CharacterController controller;
  public Camera camera;

  public float speed;
  public float turnspeed;
  public float MouseSensitivity;

  float lookSensitivity = 5;
  float mouseX,mouseY;
  public Transform playerBody;
  float xRotation = 0f;

  //private Vector3 moveDirection = Vector3.zero;

  public KeyCode forward;
  public KeyCode back;
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
      camera = GetComponent<Camera>();

    }


void MomoPlayerMovement()
{

  if(isLocalPlayer)
  {

    if(Input.GetKey(left))
  	{
  		rb.MovePosition(transform.position + Vector3.left * speed);
  	}

  	if(Input.GetKey(right))
  	{
  		rb.MovePosition(transform.position + Vector3.right * speed);
  	}

  	if(Input.GetKey(forward))
  	{
  		rb.MovePosition(transform.position + Vector3.forward * speed );
  	}

  	if(Input.GetKey(back))
  	{
  rb.MovePosition(transform.position + Vector3.back * speed);
  	}

  }
    //rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * MouseSensitivity, 0)));
    //rb.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * speed ) + (transform.right * Input.GetAxis("Horizontal") * speed ));
    //if (Input.GetKey(KeyCode.E))
    //{
      //  rb.MovePosition(transform.position + Vector3.up * speed );
  //  }
  //  if (Input.GetKey(KeyCode.Q))
  //  {
  //      rb.MovePosition(transform.position + Vector3.down * speed);
  //  }

    //float sensitivity = 0.01f;
    //Vector3 vp = camera.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane));
    //vp.x -= 0.5f;
    //vp.y -= 0.5f;
    //vp.x *= sensitivity;
    //vp.y *= sensitivity;
    //vp.x += 0.5f;
    //vp.y += 0.5f;

    //Vector3 sp = camera.ViewportToScreenPoint(vp);

    //Vector3 v = camera.ScreenToWorldPoint(sp);
    //transform.LookAt(v, Vector3.up);

  //  if (controller.isGrounded)
    //    {
      //      moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //    moveDirection = transform.TransformDirection(moveDirection);
          //  moveDirection *= walkSpeed;
            //if (Input.GetButton("Jump"))
              //  moveDirection.y = jumpSpeed;
        //}
        //moveDirection.y -= gravity * Time.deltaTime;
        //controller.Move(moveDirection * Time.deltaTime);




//        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
  //  float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

    //xRotation -= mouseY;
    //xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    //transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

    //playerBody.Rotate(Vector3.up * mouseX);



  //}



}

    // Update is called once per frame
    void Update()
    {
      MomoPlayerMovement();
    }
}
