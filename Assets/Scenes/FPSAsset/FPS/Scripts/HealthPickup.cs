using UnityEngine;
using Mirror;

//Script by Monique Leung November-December2020 for Computer Programming 12 G, Project Name = EXHILE

public class HealthPickup : NetworkBehaviour
{
    [Header("Parameters")]
    [Tooltip("Amount of health to heal on pickup")]
    public float healAmount;

    Pickup m_Pickup;

    void Start()
    {
        m_Pickup = GetComponent<Pickup>();
        DebugUtility.HandleErrorIfNullGetComponent<Pickup, HealthPickup>(m_Pickup, this, gameObject);

        // Subscribe to pickup action
        m_Pickup.onPick += OnPicked;
    }

    void OnPicked(PlayerCharacterController player)
    {
        Health playerHealth = player.GetComponent<Health>();
        if (playerHealth && playerHealth.canPickup())
        {
            playerHealth.Heal(healAmount);

            m_Pickup.PlayPickupFeedback();

            Destroy(gameObject);
        }
    }
}
