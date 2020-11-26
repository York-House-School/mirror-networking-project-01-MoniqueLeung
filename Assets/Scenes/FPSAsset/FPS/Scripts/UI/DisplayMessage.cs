﻿using UnityEngine;
using Mirror;

//Script by Monique Leung November-December2020 for Computer Programming 12 G, Project Name = EXHILE
public class DisplayMessage : NetworkBehaviour
{
    [Tooltip("The text that will be displayed")]
    [TextArea]
    public string message;
    [Tooltip("Prefab for the message")]
    public GameObject messagePrefab;
    [Tooltip("Delay before displaying the message")]
    public float delayBeforeShowing;

    float m_InitTime = float.NegativeInfinity;
    bool m_WasDisplayed;
    DisplayMessageManager m_DisplayMessageManager;

    void Start()
    {
        m_InitTime = Time.time;
        m_DisplayMessageManager = FindObjectOfType<DisplayMessageManager>();
        DebugUtility.HandleErrorIfNullFindObject<DisplayMessageManager, DisplayMessage>(m_DisplayMessageManager, this);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_WasDisplayed)
            return;

        if (Time.time - m_InitTime > delayBeforeShowing)
        {
            var messageInstance = Instantiate(messagePrefab, m_DisplayMessageManager.DisplayMessageRect);
            var notification = messageInstance.GetComponent<NotificationToast>();
            if (notification)
            {
                notification.Initialize(message);
            }

            m_WasDisplayed = true;
        }
    }
}
