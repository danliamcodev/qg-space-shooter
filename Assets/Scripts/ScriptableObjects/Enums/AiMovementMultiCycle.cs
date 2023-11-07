using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AI Movement Multi Cycle", menuName = "AI/Movement/Cycles/Multi")]
public class AiMovementMultiCycle : AiMovementCycle
{
    [Header("Parameters")]
    [SerializeField] List<AiMovementCycle> m_movement_cylces;

    public override List<AiMovementStep> GetSteps()
    {
        List<AiMovementStep> movement_steps = new List<AiMovementStep>();
        for (int i = 0; i < m_movement_cylces.Count; i++)
        {
            AiMovementCycle movement_cycle = m_movement_cylces[i];
            movement_steps.AddRange(movement_cycle.GetSteps());
        }
        return movement_steps;
    }
}
