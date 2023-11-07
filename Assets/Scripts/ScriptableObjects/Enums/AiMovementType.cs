using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AiMovementType : ScriptableObject
{
    public abstract void Move(Transform p_transform);
}
