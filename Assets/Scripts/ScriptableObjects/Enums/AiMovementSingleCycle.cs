using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AI Movement Single Cycle", menuName = "AI/Movement/Cycles/Single")]
public class AiMovementSingleCycle : AiMovementCycle
{
    [Header("Parameters")]
    [SerializeField] List<AiMovementStep> m_movement_steps;

    public override List<AiMovementStep> GetSteps()
    {
        return m_movement_steps;
    }
}
