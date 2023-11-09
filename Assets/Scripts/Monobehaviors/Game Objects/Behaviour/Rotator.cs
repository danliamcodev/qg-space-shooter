using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
	[Header("Parameter")]
	public float m_rotation_speed = 200;
	private void Start()
    {
		StartCoroutine(RotateTask());
    }
    private IEnumerator RotateTask()
	{
		while (true)
		{
			transform.rotation *= Quaternion.AngleAxis(m_rotation_speed * Time.deltaTime, new Vector3(1, 1, 0));

			yield return null;
		}
	}
}
