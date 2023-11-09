using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player Bullet
/// </summary>
public class PlayerBullet : MonoBehaviour
{
	[Header("Reference")]
	[SerializeField] ObjectPoolController m_bullet_pool_controller;

	[Header("Parameter")]
	public float m_move_speed = 5;
	public float m_life_time = 2;

	//
	void Update()
	{
		transform.position += transform.up * m_move_speed * Time.deltaTime;

		m_life_time -= Time.deltaTime;
		if (m_life_time <= 0)
		{
			ReturnToPool();
		}
	}

	public void ReturnToPool()
	{
		m_bullet_pool_controller.ReturnObject(this.gameObject);
	}
}
