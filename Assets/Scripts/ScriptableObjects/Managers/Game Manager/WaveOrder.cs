using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave Order", menuName = "Gameplay/Wave Order")]
public class WaveOrder : ScriptableObject
{
    [Header("Parameters")]
    [SerializeField] List<GameObject> m_wave_order;

    public List<GameObject> wave_order { get { return m_wave_order; } }
}
