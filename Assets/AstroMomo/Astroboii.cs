using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.Networking;

//Script by Monique Leung November-January2020 for Computer Programming 12 G Project Name = EXHILE
namespace AstroMomo
{
  public class Astroboii : NetworkBehaviour
  {
    [Header("Components")]
    public UnityEngine.AI.NavMeshAgent agent;
    public Animator animator;

    [Header("Movement")]
    public float rotationSpeed = 100;
    public float speed;
    //public float turnSpeed;
    public float gravity;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    [Header("Firing")]
    public KeyCode shootKey = KeyCode.Space;
    public GameObject projectilePrefab;
    public Transform projectileMount;

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



    void Start ()
    {
      controller = GetComponent <CharacterController>();

      
    }

    void Update()
    {
      if(Camera.main)
      {
          nameText.text = playerName;
          nameText.transform.rotation = Camera.main.transform.rotation;

      }



      // movement for local player
      if (!isLocalPlayer)
          return;

      //Set local players name color to green
      nameText.color = Color.green;

      if (!allowMovement)
          return;

      if (isDead)
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
        GameObject momoprojectile = Instantiate(projectilePrefab, projectileMount.position, transform.rotation);
        momoprojectile.GetComponent<MomoProjectile>().source = gameObject;
        NetworkServer.Spawn(momoprojectile);
        RpcOnFire();
    }

    // this is called on the player that fired for all observers
    [ClientRpc]
    void RpcOnFire()
    {
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
