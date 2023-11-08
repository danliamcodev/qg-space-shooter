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

	[Header("Layout")]
	public Transform m_stage_transform;
	public Text m_stage_score_text;

	[Header("Prefab")]
	public Player m_prefab_player;
	public EnemySpawner m_prefab_enemy_spawner;

	//
	int m_game_score = 0;

    //------------------------------------------------------------------------------

    private void Start()
    {
		SetupStage();
    }

	void SetupStage()
	{
		Instance = this;

		m_game_score = 0;
		RefreshScore();

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

	public void AddScore(int a_value)
	{
		m_game_score += a_value;
		RefreshScore();
	}

	void RefreshScore()
	{
		if (m_stage_score_text)
		{
			m_stage_score_text.text = $"Score {m_game_score:00000}";
		}
	}

}
