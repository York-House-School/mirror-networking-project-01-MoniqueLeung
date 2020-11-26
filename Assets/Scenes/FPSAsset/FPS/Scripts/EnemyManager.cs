using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Mirror;

//Script by Monique Leung November-December2020 for Computer Programming 12 G, Project Name = EXHILE
public class EnemyManager : NetworkBehaviour
{
    PlayerCharacterController m_PlayerController;

    public List<EnemyController> enemies { get; private set; }
    public int numberOfEnemiesTotal { get; private set; }
    public int numberOfEnemiesRemaining => enemies.Count;

    public UnityAction<EnemyController, int> onRemoveEnemy;

    private void Awake()
    {
        m_PlayerController = FindObjectOfType<PlayerCharacterController>();
        DebugUtility.HandleErrorIfNullFindObject<PlayerCharacterController, EnemyManager>(m_PlayerController, this);

        enemies = new List<EnemyController>();
    }

    public void RegisterEnemy(EnemyController enemy)
    {
        enemies.Add(enemy);

        numberOfEnemiesTotal++;
    }

    public void UnregisterEnemy(EnemyController enemyKilled)
    {
        int enemiesRemainingNotification = numberOfEnemiesRemaining - 1;

        if (onRemoveEnemy != null)
        {
            onRemoveEnemy.Invoke(enemyKilled, enemiesRemainingNotification);
        }

        // removes the enemy from the list, so that we can keep track of how many are left on the map
        enemies.Remove(enemyKilled);
    }
}
