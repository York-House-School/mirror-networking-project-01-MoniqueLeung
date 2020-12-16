using UnityEngine;
using System.Collections;
using Mirror;

//Script by Monique Leung November-December2020 for Computer Programming 12 G, Project Name = EXHILE

public class Workingplayerscript : NetworkBehaviour {

public Transform momotheplayer;
		private Animator anim;
		private CharacterController controller;
		public Camera camera;
	//	PlayerInputHandler m_InputHandler;


		public float speed;
		public float turnSpeed;
	//	private Vector3 moveDirection = Vector3.zero;
		public float mouseSensitivity;
		//public float lookYLimit;
		//float rotationY = 0;
		public float lookSpeed;
	//	public float rotationSpeed;
	//	public float RotationMultiplier;
	//	float m_CameraVerticalAngle = 0f;

		//public float gravity = 1.0f;

private Vector3 moveDirection = Vector3.zero;
		public float walkSpeed = 6.0F;
public float jumpSpeed = 8.0F;
public float runSpeed = 8.0F;
public float gravity ;
		float yRotation;
float xRotation;
float lookSensitivity;
float currentXRotation;
float currentYRotation;
float yRotationV;
float xRotationV;


		public KeyCode left;
		public KeyCode right;
		public KeyCode forward;
    	public KeyCode back;
		public Rigidbody rb;


		void Start ()
		{
			controller = GetComponent <CharacterController>();
			anim = gameObject.GetComponentInChildren<Animator>();
			camera = GetComponent<Camera>();
			rb = GetComponent <Rigidbody>();
		}

void MomoPlayerMovement(){

	//if (Input.GetKey (forward))
	//{
	//	anim.SetInteger ("Walking", 1);
//	}
//	else {
//		anim.SetInteger ("Idle", 2);
//	}

				if(isLocalPlayer)
				{

//define each momotheplayers for each form of movement, forward,back, right, left
					if(Input.GetKey(left))
					{
							//rb.momotheplayer
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



				//	float moveHorizontal = Input.GetAxis("Horizontal");
				//	float moveVertical = Input.GetAxis("Vertical");
				//	Vector3 movement = new Vector3(moveHorizontal*50.0f, moveVertical*50.0f,0);
				//	momotheplayer.position = (transform.position + (transform.forward * Input.GetAxis("Vertical") * speed ) + (transform.right * Input.GetAxis("Horizontal") * speed ));

				//	float moveHorizontal = Input.GetAxis("Horizontal");
					//float moveVertical = Input.GetAxis("Vertical");
					//Vector3 movement = new Vector3(moveHorizontal*100.0f, moveVertical*100.0f,0);
				 //transform.position = transform.position + movement;


					//	if(Input.GetKey(left))
					//	{
					//		transform.position = transform.position + movement + speed);
					//	}

						//if(Input.GetKey(right))
						//{
						//	transform.position = transform.position + movement + speed);
						//}

						//if(Input.GetKey(forward))
						//{
							//transform.position = transform.position + movement + speed );
						//}

						//if(Input.GetKey(back))
						//{
						//	transform.position = transform.position + movement + speed);
						//}








	//rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse Y") * mouseSensitivity)));
	//	rb.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * speed ) + (transform.right * Input.GetAxis("Horizontal") * speed ));



	//float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
	  //      float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

	    //    xRotation -= mouseY;
	        //xRotation = Mathf.Clamp(xRotation, -90f, 90f);
	      //  transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

	       // transform.Rotate(Vector3.up * mouseX);

					//moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
					       // moveDirection = transform.TransformDirection(moveDirection);
					      //  moveDirection *= walkSpeed;
					     //   if (Input.GetButton("Jump"))
					    //        moveDirection.y = jumpSpeed;
						//					moveDirection.y -= gravity * Time.deltaTime;
					//	controller.Move(moveDirection * Time.deltaTime);
					}
//	transform.Rotate(new Vector3(0f, (m_InputHandler.GetLookInputsHorizontal() * rotationSpeed * RotationMultiplier), 0f), Space.Self);
//	m_CameraVerticalAngle += m_InputHandler.GetLookInputsVertical() * rotationSpeed * RotationMultiplier;
//	m_CameraVerticalAngle = Mathf.Clamp(m_CameraVerticalAngle, -89f, 89f);
//	camera.transform.localEulerAngles = new Vector3(m_CameraVerticalAngle, 0, 0);



//rotationY += -Input.GetAxis("Mouse Y") * lookSpeed;
	//rotationY = Mathf.Clamp(rotationY, -lookYLimit, lookYLimit);
	//camera.transform.localRotation = Quaternion.Euler(rotationY, 0, 0);
//transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);


//	Vector3 vp = camera.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane));
//	vp.x -= 0.5f;
//	vp.y -= 0.5f;
//	vp.x *= MouseSensitivity;
//	vp.y *= MouseSensitivity;
//	vp.x += 0.5f;
//	vp.y += 0.5f;

	//Vector3 sp = camera.ViewportToScreenPoint(vp);

	//Vector3 v = camera.ScreenToWorldPoint(sp);
	//transform.LookAt (v, Vector3.up);

//	float turn = Input.GetAxis("Horizontal");
//	transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
//	rb.MovePosition(transform.position * turn);

}



void Update()

		{
			MomoPlayerMovement();
		}

}
