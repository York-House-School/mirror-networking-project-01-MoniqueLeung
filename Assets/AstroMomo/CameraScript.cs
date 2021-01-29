using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Mirror;
//script by Monique Leung November-January 2021 for the Computer Programming 12 G Project Name = EXHILE
namespace AstroMomo
{
  public class CameraScript : MonoBehaviour
  {
      private const float Y_ANGLE_MIN = 0.0f;
      private const float Y_ANGLE_MAX = 50.0f;

      public Transform lookAt;
      public Transform camTransform;
      public float distance = 5.0f;

      private float currentX = 0.0f;
      private float currentY = 45.0f;
      private float sensitivityX = 20.0f;
      private float sensitivityY = 20.0f;

      // Start is called before the first frame update
      private void Start()
      {

          camTransform = transform;
      }
      // Update is called once per frame
      private void Update()
      {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
      }
      private void LateUpdate()
      {
        
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
      }
  //last bracket for public class
  }
//last bracket for namespace
}
