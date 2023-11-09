using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("References")]
    [SerializeField] WeaponsList m_weapons_list;
    [SerializeField] Weapon m_active_weapon;

    List<Weapon> weapons = new List<Weapon>();

    private void Start()
    {
        for (int i = 0; i < m_weapons_list.weapons.Count; i++)
        {
            Weapon weapon = Instantiate(m_weapons_list.weapons[i].weapon, transform);
            weapons.Add(weapon);
            weapon.gameObject.SetActive(false);
        }
        StartCoroutine(DetectShootInputTask());
    }

    public void ActivateWeapon(WeaponPower p_weapon_power)
    {
        m_active_weapon.gameObject.SetActive(false);
        for (int i = 0; i < m_weapons_list.weapons.Count; i++)
        {
            if (m_weapons_list.weapons[i] == p_weapon_power)
            {
                weapons[i].gameObject.SetActive(true);
                m_active_weapon = weapons[i];
            }
        }
    }

    private IEnumerator DetectShootInputTask()
    { 
        while (true)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                m_active_weapon.Shoot();
            }
            yield return null;
        }
    }
}
