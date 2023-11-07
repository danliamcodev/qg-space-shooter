using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AI Movement Straight", menuName = "AI/Movement/Types/Straight")]
public class AiMovementOneDirection : AiMovementType
{
	[Header("Parameters")]
	[SerializeField] Vector3 m_direction;
	[SerializeField] Vector3 m_move_speed;
    public override void Move(Transform p_transform)
    {
		Vector3 movement = new Vector3(m_direction.x * m_move_speed.x, m_direction.y * m_move_speed.y, m_direction.z * m_move_speed.z) * Time.deltaTime;
		p_transform.position += movement;
		/*
		while (true)
		{
			Vector3 movement = new Vector3(m_direction.x * m_move_speed.x, m_direction.y * m_move_speed.y, m_direction.z * m_move_speed.z) * Time.deltaTime;
			p_transform.position += movement;
			yield return null;
		}
		*/
	}
}
