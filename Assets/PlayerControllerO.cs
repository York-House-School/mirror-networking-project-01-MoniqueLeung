using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerO : MonoBehaviour
{
    public Slider speedSlider;
    public float speed;
    public int speedInt;

    private Rigidbody rb;
    private Renderer rend;
    private float moveHorizontal;
    private float moveVertical;


    private string ballColor;

    public string pastColor;

    public KeyCode left;
    public KeyCode right;
    public KeyCode forward;
    public KeyCode back;

    private int count;
    public TextMesh scoreText;
    public TextMesh winText;
    private int counttime;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        winText.gameObject.SetActive(false);
        count = 0;
        SetScoreText();

        speedSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        rend = GetComponent<Renderer>();
    }

     void Update()
    {
getBallColor();
    }

    // Update is called once per frame
    void FixedUpdate()
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetScoreText();
        }

        if (count > 11)
        {
            winText.gameObject.SetActive(true);
        }

    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + count.ToString();
    }



    public void ValueChangeCheck()
    {
        speed = speedSlider.value * 10;
        //speedInt = (int)speed;
        //Debug.Log("The speed value changed to " + speed.ToString() + " or " + speedInt.ToString() + " as an int.");
        switch ((int)speed)
        {

          //This is the part of the code that gets the ball color
            case 0:
                rend.material.SetColor("_Color", Color.red);
                ballColor = "red";
                //Debug.Log(ballColor);
                break;
            case 5:
                rend.material.SetColor("_Color", Color.yellow);
                ballColor = "yellow";
                //Debug.Log(ballColor);
                break;
            case 10:
                rend.material.SetColor("_Color", Color.blue);
                ballColor = "blue";
                //Debug.Log(ballColor);
                break;
        }

    }

    public void getBallColor()
  {

      if(colorChange()){
        pastColor = ballColor;
        Debug.Log(ballColor);
      }

    }




      public bool colorChange(){
        if(pastColor != ballColor){
        //  pastColor != ballColor;
            return true;
        }else{
          return false;
        }
      }





  }
