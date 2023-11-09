using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[Header("References")]
	[SerializeField] AiMovementCycle m_movement_cycle;
	[SerializeField] SoundManager m_sound_manager;
	[SerializeField] ObjectPoolController m_enemy_pool_controller;
	[SerializeField] ObjectPoolController m_explosion_vfx_controller;

	[Header("Events")]
	[SerializeField] VoidEvent m_enemy_killed;

	[Header("Parameter")]
	public float m_move_speed = 5;
	public float m_rotation_speed = 200;
	public float m_life_time = 5;
	public int m_score = 100;
	[SerializeField] AudioClip m_explosion_sfx;

	//------------------------------------------------------------------------------

	private void Start()
	{
		StartCoroutine(MainCoroutine());
	}

	public void ConfigureEnemy(AiMovementCycle p_movement_cycle)
    {
		m_movement_cycle = p_movement_cycle;
    }

	public void ActivateEnemy()
    {
		StartCoroutine(m_movement_cycle.MoveTask(this.transform));
	}

	private void ReturnToPool()
	{
		m_enemy_pool_controller.ReturnObject(this.gameObject);
	}

	//
	private IEnumerator MainCoroutine()
	{
		while (true)
		{
			//move
			//transform.position += new Vector3(0, -1, 0) * m_move_speed * Time.deltaTime;

			//animation
			transform.rotation *= Quaternion.AngleAxis(m_rotation_speed * Time.deltaTime, new Vector3(1, 1, 0));


			//	
			m_life_time -= Time.deltaTime;
			if (m_life_time <= 0)
			{
				ReturnToPool();
				yield break;
			}

			yield return null;
		}
	}

	//------------------------------------------------------------------------------

	private void OnCollisionEnter(Collision collision)
	{
		PlayerBullet player_bullet = collision.transform.GetComponent<PlayerBullet>();
		if (player_bullet)
		{
			DestroyByPlayer(player_bullet);
		}
	}

	void DestroyByPlayer(PlayerBullet a_player_bullet)
	{
		//add score
		m_enemy_killed.Raise();

		//delete bullet
		if (a_player_bullet)
		{
			a_player_bullet.ReturnToPool();
		}

		m_sound_manager.PlaySFX(m_explosion_sfx);
		ParticleSystem explosion_vfx = m_explosion_vfx_controller.GetObject().GetComponent<ParticleSystem>();
		explosion_vfx.transform.position = this.transform.position;
		explosion_vfx.gameObject.SetActive(false);
		explosion_vfx.gameObject.SetActive(true);

		//delete self
		ReturnToPool();
	}
}
