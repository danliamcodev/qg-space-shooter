using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Stage main loop
/// </summary>
public class StageLoop : MonoBehaviour
{
	#region static 
	static public StageLoop Instance { get; private set; }
	#endregion

	[Header("Events")]
	[SerializeField] VoidEvent m_score_updated;

	[Header("References")]
	[SerializeField] SoundManager m_sound_manager;
	[SerializeField] IntVariable m_player_score;

	[Header("Layout")]
	public Transform m_stage_transform;

	[Header("Prefab")]
	public Player m_prefab_player;
	public EnemySpawner m_prefab_enemy_spawner;

	[Header("Parameters")]
	[SerializeField] AudioClip m_bgm;

    //------------------------------------------------------------------------------

    private void Start()
    {
		SetupStage();
		m_sound_manager.PlayBGM(m_bgm);
    }

	void SetupStage()
	{
		Instance = this;

		m_player_score.SetValue(0);
		m_score_updated.Raise();


		//create player
		{
			Player player = Instantiate(m_prefab_player, m_stage_transform);
			if (player)
			{
				player.transform.position = new Vector3(0, -4, 0);
				player.StartRunning();
			}
		}
	}

	void CleanupStage()
	{
		//delete all object in Stage
		{
			for (var n = 0; n < m_stage_transform.childCount; ++n)
			{
				Transform temp = m_stage_transform.GetChild(n);
				GameObject.Destroy(temp.gameObject);
			}
		}

		Instance = null;
	}

	//------------------------------------------------------------------------------

}
