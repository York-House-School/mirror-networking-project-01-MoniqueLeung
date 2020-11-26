using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

//Script by Monique Leung November-December2020 for Computer Programming 12 G, Project Name = EXHILE

public class FollowPlayer : NetworkBehaviour
{
    private Transform m_PlayerTransform;
    private Vector3 m_OriginalOffset;

    void Start()
    {
        PlayerCharacterController playerCharacterController = GameObject.FindObjectOfType<PlayerCharacterController>();
        DebugUtility.HandleErrorIfNullFindObject<PlayerCharacterController, FollowPlayer>(playerCharacterController, this);

        m_PlayerTransform = playerCharacterController.transform;

        m_OriginalOffset = transform.position - m_PlayerTransform.position;
    }

    void LateUpdate()
    {
        transform.position = m_PlayerTransform.position + m_OriginalOffset;
    }
}
