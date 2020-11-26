using UnityEngine;
using UnityEngine.EventSystems;
using Mirror;

//Script by Monique Leung November-December2020 for Computer Programming 12 G, Project Name = EXHILE
public class ToggleGameObjectButton : NetworkBehaviour
{
    public GameObject objectToToggle;
    public bool resetSelectionAfterClick;

    void Update()
    {
        if (objectToToggle.activeSelf && Input.GetButtonDown(GameConstants.k_ButtonNameCancel))
        {
            SetGameObjectActive(false);
        }
    }

    public void SetGameObjectActive(bool active)
    {
        objectToToggle.SetActive(active);

        if (resetSelectionAfterClick)
            EventSystem.current.SetSelectedGameObject(null);
    }
}
