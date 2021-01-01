using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compsci : MonoBehaviour
{

  bool Programming12isFun = true;
  bool ComputerScienceandSTEMisfun = true;

  string messageToYouHuman;
    // Start is called before the first frame update
    void Start()
    {

    }

void MomoMessage(){

  if(Programming12isFun && ComputerScienceandSTEMisfun){
      messageToYouHuman = "You are Intelligent and you are invited to join Mo";
      messageToYouHuman = "Youare";
  }
  else{
    messageToYouHuman = "CompilerError";
  }

  Debug.Log(messageToYouHuman);
}
    // Update is called once per frame
    void Update()
    {
        MomoMessage();
    }
}
