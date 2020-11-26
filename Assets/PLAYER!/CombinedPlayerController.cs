using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinedPlayerController : MonoBehaviour
{

    private Rigidbody rb;
    public float MouseSensitivity;
    public float speed;
    private Light glow;
    private Camera mycam;
    //private float vp;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
       glow = GetComponent<Light>();
        mycam = GetComponent<Camera>();

    }
    void FixedUpdate()
    {
        //(monique)
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

        glow.range = 5;

        //taken from online source(amy), makes the camera look where the mouse is on the screen
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

}
