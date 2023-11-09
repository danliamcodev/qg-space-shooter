using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] AiMovementCycle m_ai_movement_cycle;

    [Header("References")]
    [SerializeField] List<EnemySpawner> m_enemy_spawners;



    private void OnEnable()
    {
        foreach (EnemySpawner enemy_spawner in m_enemy_spawners)
        {
            enemy_spawner.SpawnEnemies(m_ai_movement_cycle);
        }
    }
}
