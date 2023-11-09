using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
	[Header("Events")]
	[SerializeField] VoidEvent m_waves_finished;
    [Header("References")]
    [SerializeField] WaveOrder m_wave_order;
    [SerializeField] float m_spawn_interval = 5f;

    private void Start()
    {
		StartCoroutine(SpawnWavesTask());
    }

	public IEnumerator SpawnWavesTask()
	{
		int waves_spawned = 0;
		while (waves_spawned < m_wave_order.wave_order.Count)
		{
			GameObject wave = Instantiate(m_wave_order.wave_order[waves_spawned], transform);
			wave.transform.position = transform.position;
			wave.SetActive(true);
			waves_spawned++;

			yield return new WaitForSeconds(m_spawn_interval);
		}

		yield return new WaitForSeconds(2f);
		m_waves_finished.Raise();
	}
}
