using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Mirror;

//Script by Monique Leung November-December2020 for Computer Programming 12 G, Project Name = EXHILE
public class LoadSceneButton : NetworkBehaviour
{
    public string sceneName = "";

    private void Update()
    {
        if(EventSystem.current.currentSelectedGameObject == gameObject
            && Input.GetButtonDown(GameConstants.k_ButtonNameSubmit))
        {
            LoadTargetScene();
        }
    }

    public void LoadTargetScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
