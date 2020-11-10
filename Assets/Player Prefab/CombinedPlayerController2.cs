using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CombinedPlayerController2 : NetworkBehaviour
{

    //Comments made by Monique
    //I made the rigid body public so that I could assign the rigid body that i wanted onto the player
    public Rigidbody rb;


    public float MouseSensitivity;
    //I made the speed float public so that I could edit it directly in the UI while testing my game
    public float speed;

    private Light glow;

    //The camera is private as I won't be needing to change the camera as the player is the camera.
    private Camera mycam;


    private void Start()
    {
        //Before the first frame the rigid body, light, and camera are identified
        rb = GetComponent<Rigidbody>();
       glow = GetComponent<Light>();
        //the glow is the light that radiates off of the player

        mycam = GetComponent<Camera>();

    }
    void FixedUpdate()
    {
        //This is the part of the script that moves the position of the player's rigid boy. The player uses the AWSD keys to move forward, left right, and back
        rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * MouseSensitivity, 0)));
        rb.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * speed ) + (transform.right * Input.GetAxis("Horizontal") * speed ));

        //The player moves up/ ascennds with the key Q
      if (Input.GetKey(KeyCode.Q))
        {
            rb.MovePosition(transform.position + Vector3.up * speed );
        }

      //The player descends with the key E
      if (Input.GetKey(KeyCode.E))
        {
            rb.MovePosition(transform.position + Vector3.down * speed);
        }


            glow.range = 3;



        //taken from online source, makes the camera look where the mouse is on the screen
        float sensitivity = 0.01f;
        Vector3 vp = mycam.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mycam.nearClipPlane));
        vp.x -= 0.5f;
        vp.y -= 0.5f;
        vp.x *= sensitivity;
        vp.y *= sensitivity;
        vp.x += 0.5f;
        vp.y += 0.5f;

        Vector3 sp = mycam.ViewportToScreenPoint(vp);

        Vector3 v = mycam.ScreenToWorldPoint(sp);
        transform.LookAt(v, Vector3.up);
    }

        void Update()
    {


    }
}
