
using UnityEngine;
using Mirror;

//Script by Monique Leung November-December2020 for Computer Programming 12 G, Project Name = EXHILE
public class PositionBobbing : NetworkBehaviour
{
    [Tooltip("Frequency at which the item will move up and down")]
    public float verticalBobFrequency = 1f;
    [Tooltip("Distance the item will move up and down")]
    public float bobbingAmount = 0.5f;

    Vector3 m_StartPosition;

    void Start()
    {
        // Remember start position for animation
        m_StartPosition = transform.position;
    }

    void Update()
    {
        // Handle bobbing
        float bobbingAnimationPhase = ((Mathf.Sin(Time.time * verticalBobFrequency) * 0.5f) + 0.5f) * bobbingAmount;
        transform.position = m_StartPosition + Vector3.up * bobbingAnimationPhase;
    }
}
