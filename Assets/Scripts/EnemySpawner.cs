using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Enemy SpawnPoint
/// </summary>
public class EnemySpawner : MonoBehaviour
{
	[Header("Prefab")]
	[SerializeField] Enemy m_prefab_enemy;

	[Header("Parameter")]
	[SerializeField] float m_spawn_delay = 0f;
	[SerializeField] float m_spawn_interval = 2;
	[SerializeField] int m_spawn_count = 1;

    //------------------------------------------------------------------------------

    public void SpawnEnemies(AiMovementCycle p_ai_movement_cycle)
	{
		StartCoroutine(SpawnEnemiesTask(p_ai_movement_cycle));
	}

	public IEnumerator SpawnEnemiesTask(AiMovementCycle p_ai_movement_cycle)
	{
		yield return new WaitForSeconds(m_spawn_delay);
		int enemies_spawned = 0;
		while (enemies_spawned < m_spawn_count)
		{
			//spawn enemy
			if (m_prefab_enemy)
			{
				Enemy enemy = Instantiate(m_prefab_enemy, transform.parent);
				enemy.transform.position = transform.position;
				enemy.ConfigureEnemy(p_ai_movement_cycle);
				enemy.ActivateEnemy();
				enemies_spawned++;
			}

			yield return new WaitForSeconds(m_spawn_interval);
		}
	}

	//------------------------------------------------------------------------------

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, 1.0f);
	}
}
