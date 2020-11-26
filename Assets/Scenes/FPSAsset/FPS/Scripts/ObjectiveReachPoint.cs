using UnityEngine;
using Mirror;

//Script by Monique Leung November-December2020 for Computer Programming 12 G, Project Name = EXHILE
[RequireComponent(typeof(Objective), typeof(Collider))]
public class ObjectiveReachPoint : NetworkBehaviour
{
    [Tooltip("Visible transform that will be destroyed once the objective is completed")]
    public Transform destroyRoot;

    Objective m_Objective;

    void Awake()
    {
        m_Objective = GetComponent<Objective>();
        DebugUtility.HandleErrorIfNullGetComponent<Objective, ObjectiveReachPoint>(m_Objective, this, gameObject);

        if (destroyRoot == null)
            destroyRoot = transform;
    }

    void OnTriggerEnter(Collider other)
    {
        if (m_Objective.isCompleted)
            return;

        var player = other.GetComponent<PlayerCharacterController>();
        // test if the other collider contains a PlayerCharacterController, then complete
        if (player != null)
        {
            m_Objective.CompleteObjective(string.Empty, string.Empty, "Objective complete : " + m_Objective.title);

            // destroy the transform, will remove the compass marker if it has one
            Destroy(destroyRoot.gameObject);
        }
    }
}
