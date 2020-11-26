using UnityEngine;
using UnityEngine.UI;
using Mirror;

//Script by Monique Leung November-December2020 for Computer Programming 12 G, Project Name = EXHILE
public class StanceHUD : NetworkBehaviour
{
    [Tooltip("Image component for the stance sprites")]
    public Image stanceImage;
    [Tooltip("Sprite to display when standing")]
    public Sprite standingSprite;
    [Tooltip("Sprite to display when crouching")]
    public Sprite crouchingSprite;

    private void Start()
    {
        PlayerCharacterController character = FindObjectOfType<PlayerCharacterController>();
        DebugUtility.HandleErrorIfNullFindObject<PlayerCharacterController, StanceHUD>(character, this);
        character.onStanceChanged += OnStanceChanged;

        OnStanceChanged(character.isCrouching);
    }

    void OnStanceChanged(bool crouched)
    {
        stanceImage.sprite = crouched ? crouchingSprite : standingSprite;
    }
}
