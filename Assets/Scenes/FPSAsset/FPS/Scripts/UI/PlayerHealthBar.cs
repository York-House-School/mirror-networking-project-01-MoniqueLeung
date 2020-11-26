using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

//Script by Monique Leung November-December2020 for Computer Programming 12 G, Project Name = EXHILE
public class PlayerHealthBar : NetworkBehaviour
{
    [Tooltip("Image component dispplaying current health")]
    public Image healthFillImage;

    Health m_PlayerHealth;

    private void Start()
    {
        PlayerCharacterController playerCharacterController = GameObject.FindObjectOfType<PlayerCharacterController>();
        DebugUtility.HandleErrorIfNullFindObject<PlayerCharacterController, PlayerHealthBar>(playerCharacterController, this);

        m_PlayerHealth = playerCharacterController.GetComponent<Health>();
        DebugUtility.HandleErrorIfNullGetComponent<Health, PlayerHealthBar>(m_PlayerHealth, this, playerCharacterController.gameObject);
    }

    void Update()
    {
        // update health bar value
        healthFillImage.fillAmount = m_PlayerHealth.currentHealth / m_PlayerHealth.maxHealth;
    }
}
