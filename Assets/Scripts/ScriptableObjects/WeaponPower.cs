using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Weapon Power", menuName = "Player/Weapon Power")]
public class WeaponPower : Power
{
    [Header("Parameters")]
    [SerializeField] Weapon m_weapon_prefab;
    public override void ApplyToPlayer(Player p_player)
    {
        if (p_player.TryGetComponent<PlayerShooting>(out PlayerShooting player_shooting))
        {
            player_shooting.ActivateWeapon(this);
        }
    }
    public Weapon weapon { get { return m_weapon_prefab; } }
}
