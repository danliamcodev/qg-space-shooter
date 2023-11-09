using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
	[Header("Parameter")]
	[SerializeField] float m_move_speed = 5;
	[SerializeField] Vector3 m_scroll_direction;

    private void Start()
    {
		StartCoroutine(ScrollTask());
    }

    private IEnumerator ScrollTask()
    {
		while (true)
		{
			//move
			transform.position += m_scroll_direction * m_move_speed * Time.deltaTime;

			yield return null;
		}
	}
}
