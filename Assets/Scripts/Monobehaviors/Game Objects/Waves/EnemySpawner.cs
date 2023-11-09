using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Enemy SpawnPoint
/// </summary>
public class EnemySpawner : MonoBehaviour
{
	[Header("References")]
	[SerializeField] ObjectPoolController m_enemy_pool_controller;

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
			Enemy enemy = m_enemy_pool_controller.GetObject().GetComponent<Enemy>();
			enemy.transform.position = transform.position;
			enemy.gameObject.SetActive(true);
			enemy.ConfigureEnemy(p_ai_movement_cycle);
			enemy.ActivateEnemy();
			enemies_spawned++;
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
