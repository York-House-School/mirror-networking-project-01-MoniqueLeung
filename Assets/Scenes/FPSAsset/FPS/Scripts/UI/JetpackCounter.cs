﻿using UnityEngine;
using UnityEngine.UI;
using Mirror;

//Script by Monique Leung November-December2020 for Computer Programming 12 G, Project Name = EXHILE
public class JetpackCounter : NetworkBehaviour
{
    [Tooltip("Image component representing jetpack fuel")]
    public Image jetpackFillImage;
    [Tooltip("Canvas group that contains the whole UI for the jetack")]
    public CanvasGroup mainCanvasGroup;
    [Tooltip("Component to animate the color when empty or full")]
    public FillBarColorChange fillBarColorChange;

    Jetpack m_Jetpack;

    void Awake()
    {
        m_Jetpack = FindObjectOfType<Jetpack>();
        DebugUtility.HandleErrorIfNullFindObject<Jetpack, JetpackCounter>(m_Jetpack, this);

        fillBarColorChange.Initialize(1f, 0f);
    }

    void Update()
    {
        mainCanvasGroup.gameObject.SetActive(m_Jetpack.isJetpackUnlocked);

        if (m_Jetpack.isJetpackUnlocked)
        {
            jetpackFillImage.fillAmount = m_Jetpack.currentFillRatio;
            fillBarColorChange.UpdateVisual(m_Jetpack.currentFillRatio);
        }
    }
}
