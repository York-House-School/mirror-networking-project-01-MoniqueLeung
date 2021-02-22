using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using Mirror;
//Script by Monique Leung November-January2020 for Computer Programming 12 G Project Name = EXHILE

public class MainMenuSceneButton : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenuButton()
    {
        
        NetworkManager.singleton.StopClient();
        SceneManager.LoadScene ("MainMenu");
        
    }   
}
