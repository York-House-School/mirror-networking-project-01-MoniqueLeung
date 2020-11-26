using UnityEngine;
using Mirror;

//Script by Monique Leung November-December2020 for Computer Programming 12 G, Project Name = EXHILE

public class Destructable : NetworkBehaviour
{
    Health m_Health;

    void Start()
    {
        m_Health = GetComponent<Health>();
        DebugUtility.HandleErrorIfNullGetComponent<Health, Destructable>(m_Health, this, gameObject);

        // Subscribe to damage & death actions
        m_Health.onDie += OnDie;
        m_Health.onDamaged += OnDamaged;
    }

    void OnDamaged(float damage, GameObject damageSource)
    {
        // TODO: damage reaction
    }

    void OnDie()
    {
        // this will call the OnDestroy function
        Destroy(gameObject);
    }
}
