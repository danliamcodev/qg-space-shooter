using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Power : ScriptableObject
{
    public abstract void ApplyToPlayer(Player p_player);
}
