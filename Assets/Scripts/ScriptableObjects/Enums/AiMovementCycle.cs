using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AiMovementCycle : ScriptableObject
{
    public virtual IEnumerator MoveTask(Transform p_transform)
    {
        List<AiMovementStep> movement_steps = GetSteps();
        int movement_step_index = 0;
        while (true)
        { 
            AiMovementStep movement_step = movement_steps[movement_step_index];
            float movement_duration = 0f;
            
            while (movement_duration < movement_step.duration)
            {
                movement_step.movement_type.Move(p_transform);
                movement_duration += Time.deltaTime;
                yield return null;
            }


            movement_step_index++;

            if (movement_step_index >= movement_steps.Count)
            {
                movement_step_index = 0;
            }
        }
    }

    public abstract List<AiMovementStep> GetSteps();
}

[System.Serializable]
public class AiMovementStep
{
    [Header("Parameters")]
    [SerializeField] AiMovementType m_movement_type;
    [SerializeField] float m_duration;

    public AiMovementType movement_type { get { return m_movement_type; } }
    public float duration { get { return m_duration; } }
}





