using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.AI;
using Mirror;
//Script by Monique Leung November-January2020 for Computer Programming 12 G Project Name = EXHILE
namespace AstroMomo
{
  public class MomoProjectile : NetworkBehaviour
  {

    public float destroyAfter = 1;
    public Rigidbody rigidBody;
    public float force = 1000;

    [Header("Game Stats")]
    public int damage;
    public GameObject source;

    public override void OnStartServer()
    {
        Invoke(nameof(DestroySelf), destroyAfter);
    }

    // set velocity for server and client. this way we don't have to sync the
    // position, because both the server and the client simulate it.

    void Start()
    {
        rigidBody.AddForce(transform.forward * force);
    }

    // destroy for everyone on the server
    [Server]
    void DestroySelf()
    {
        NetworkServer.Destroy(gameObject);
    }

    // ServerCallback because we don't want a warning if OnTriggerEnter is
    // called on the client

    [ServerCallback]
    void OnTriggerEnter(Collider co)
    {
        //Hit another players
        if (co.tag.Equals("Player") && co.gameObject != source)
        {
            //Apply damage
            co.GetComponent<Astroboii>().health -= damage;

            //update score on source
            source.GetComponent<Astroboii>().score += damage;
        }
            NetworkServer.Destroy(gameObject);
    }

  //public class last bracket
  }
//namespace for the last bracket
}
