using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Networking;
using UnityEngine.SceneManagement;
//using Mirror;

//Script by Monique Leung November-January2020 for Computer Programming 12 G Project Name = EXHILE

public class StartGameButton : MonoBehaviour
{
    public GameObject MainMenuPanelButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGameSceneButton()
    {
        SceneManager.LoadScene ("GameScene");
        MainMenuPanelButton.SetActive(false);

    }
}
