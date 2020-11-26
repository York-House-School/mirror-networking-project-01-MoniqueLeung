using UnityEngine;
using UnityEngine.UI;
using Mirror;

//Script by Monique Leung November-December2020 for Computer Programming 12 G, Project Name = EXHILE
public class EnemyCounter : NetworkBehaviour
{
    [Header("Enemies")]
    [Tooltip("Text component for displaying enemy objective progress")]
    public Text enemiesText;

    EnemyManager m_EnemyManager;

    void Awake()
    {
        m_EnemyManager = FindObjectOfType<EnemyManager>();
        DebugUtility.HandleErrorIfNullFindObject<EnemyManager, EnemyCounter>(m_EnemyManager, this);
    }

    void Update()
    {
        enemiesText.text = m_EnemyManager.numberOfEnemiesRemaining + "/" + m_EnemyManager.numberOfEnemiesTotal;
    }
}
