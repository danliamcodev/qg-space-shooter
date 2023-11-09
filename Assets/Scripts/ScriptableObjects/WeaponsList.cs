using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapons List", menuName = "Player/Weapons List")]

public class WeaponsList : ScriptableObject
{
    [Header("Parameters")]
    [SerializeField] List<WeaponPower> m_weapons;

    public List <WeaponPower> weapons { get
        {
            return m_weapons;
        } 
    }
}
