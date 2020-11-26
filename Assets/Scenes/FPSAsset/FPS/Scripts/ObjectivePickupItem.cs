using UnityEngine;
using Mirror;

//Script by Monique Leung November-December2020 for Computer Programming 12 G, Project Name = EXHILE
[RequireComponent(typeof(Objective))]
public class ObjectivePickupItem : NetworkBehaviour
{
    Objective m_Objective;
    Pickup m_Pickup;

    void Awake()
    {
        m_Objective = GetComponent<Objective>();
        DebugUtility.HandleErrorIfNullGetComponent<Objective, ObjectivePickupItem>(m_Objective, this, gameObject);

        m_Pickup = GetComponent<Pickup>();
        DebugUtility.HandleErrorIfNullGetComponent<Pickup, ObjectivePickupItem>(m_Pickup, this, gameObject);

        // subscribe to the onPick action on the Pickup component
        m_Pickup.onPick += OnPickup;
    }

    void OnPickup(PlayerCharacterController player)
    {
        if (m_Objective.isCompleted)
            return;

        // this will trigger the objective completion
        // it works even if the player can't pickup the item (i.e. objective pickup healthpack while at full heath)
        m_Objective.CompleteObjective(string.Empty, string.Empty, "Objective complete : " + m_Objective.title);

        if (gameObject)
        {
            Destroy(gameObject);
        }
    }
}
