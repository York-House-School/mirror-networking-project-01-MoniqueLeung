using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using UnityEngine.Networking;

//Script by Monique Leung November-January2020 for Computer Programming 12 G Project Name = EXHILE
namespace AstroMomo
{
  public class PlayerMovement : NetworkBehaviour
  {
    [Header("Components")]
    public UnityEngine.AI.NavMeshAgent agent;
    public Animator animator;

    [Header("Movement")]
    public float rotationSpeed = 100;
    public float speed;
    //public float turnSpeed;
    //gravity is the variable that I have added to mimic real life movement
    public float gravity;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    //these are the variables that are needed for shooting
    [Header("Firing")]
    public KeyCode shootKey = KeyCode.Space;
    public GameObject projectilePrefab;
    public Transform projectileMount;
    //These syncvar attributes are part of the networking feature of unity that sync all the statistics across the network
    [Header("Game Stats")]
    [SyncVar]
    public int health;
    [SyncVar]
    public int score;
    [SyncVar]
    public string playerName;
    [SyncVar]
    public bool allowMovement;
    [SyncVar]
    public bool isReady;
    public bool isDead => health <= 0;
    public TextMesh nameText;
    //ThirdPersonCamera cam;
    public Transform astroMove;
    
    //UI
   
 
    void Start ()
    {
      //the moment start is called the game will find the CharacterController from the game.
      controller = GetComponent <CharacterController>();
      //Camera.main.GetComponent<CameraFollow>();
      //Camera.main.GetComponent<CameraFollow>().setTarget(gameObject.transform);
      //cam = GameObject.Find("Camera").GetComponent<ThirdPersonCamera>();
      //cam.lookAt = transform;

      if (isLocalPlayer)
      {
        Camera.main.transform.position = this.transform.position - this.transform.forward*9 + this.transform.up*5;
        Camera.main.transform.LookAt(this.transform.position);
        Camera.main.transform.parent = this.transform;
      }
    }

    void Update()
    {
      if(isLocalPlayer)
      {
          nameText.text = playerName;
          //Camera.main.GetComponent<CameraFollow>().enabled = true;
          //nameText.transform.rotation = Camera.main.transform.rotation;
          
      }
      // movement for local player
      if (!isLocalPlayer)
      {
          return;
      }
          

      //Set local players name color to green
      nameText.color = Color.green;

      if (!allowMovement)
          return;

          
      // rotatation from the tank script
      float horizontal = Input.GetAxis("Horizontal");
      transform.Rotate(0, horizontal * rotationSpeed * Time.deltaTime, 0);
      // movement from the tank script
      if (Input.GetKey ("w"))
      {
        //float vertical = Input.GetAxis("Vertical");
        //Vector3 forward = transform.TransformDirection(Vector3.forward);
        //agent.velocity = forward * Mathf.Max(vertical, 0) * agent.speed;
        moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
        float turn = Input.GetAxis("Horizontal");
        transform.Rotate(0, turn * rotationSpeed * Time.deltaTime, 0);
        controller.Move(moveDirection * Time.deltaTime);
        moveDirection.y -= gravity * Time.deltaTime;
        animator.SetInteger("AnimationPar", 1);
      }
      else
      {
        animator.SetInteger ("AnimationPar", 0);
      }
      //movement from astronaut prefab player script
      //if (Input.GetKey ("w"))
      //{
			//	animator.SetInteger ("AnimationPar", 1);
			//}
      //else
      //{
			//	animator.SetInteger ("AnimationPar", 0);
			//}
		  //	if(controller.isGrounded)
      //  {
		  //		moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
		  //	}
			//float turn = Input.GetAxis("Horizontal");
			//transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
			//controller.Move(moveDirection * Time.deltaTime);
			//moveDirection.y -= gravity * Time.deltaTime;
      // shoot
      if (Input.GetKeyDown(shootKey))
      {
          CmdFire();
      }
    }
    //called on the server
    [Command]
    void CmdFire()
    {
        //the momoprojectile are the projectiles that the players shoot out when they hit the space bar
        GameObject momoprojectile = Instantiate(projectilePrefab, projectileMount.position, transform.rotation);
        momoprojectile.GetComponent<MomoProjectile>().source = gameObject;
        NetworkServer.Spawn(momoprojectile);
        RpcOnFire();
    }
    // this is called on the player that fired for all observers
    [ClientRpc]
    void RpcOnFire()
    {
        //on the trigger shoot, which is space in my case the animation will run for the projectile.
        animator.SetTrigger("Shoot");
    }
    public void SendReadyToServer(string playername)
    {
        if (!isLocalPlayer)
            return;
        CmdReady(playername);
    }
    [Command]
    void CmdReady(string playername)
    {
        if (string.IsNullOrEmpty(playername))
        {
            playerName = "PLAYER" + Random.Range(1, 99);
        }
        else
        {
            playerName = playername;
        }
        isReady = true;
    }

  //last bracket for public class
  }
//last bracket for namespace
}
