using UnityEngine;
using System.Collections;
using Mirror;

public class Player : NetworkBehaviour {

		private Animator anim;
		private CharacterController controller;

		public float speed;
		public float turnSpeed;
		private Vector3 moveDirection = Vector3.zero;
		//public float gravity = 1.0f;


		public KeyCode left;
		public KeyCode right;
		public KeyCode forward;
		public KeyCode back;
		public Rigidbody rb;


		void Start () {
			controller = GetComponent <CharacterController>();
			anim = gameObject.GetComponentInChildren<Animator>();
		}

void MomoPlayerMovement(){

	if (Input.GetKey (forward))
	{
		anim.SetInteger ("Walking", 1);
	}
	else {
		anim.SetInteger ("Idle", 2);
	}

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

//	float turn = Input.GetAxis("Horizontal");
	//transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
//	rb.MovePosition(transform.position * turn);

}

void Update(){
	MomoPlayerMovement();
}

}
