using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Parameter")]
    [SerializeField] float m_fire_rate = 0.1f;
    [SerializeField] AudioClip m_shoot_sfx;

    [Header("References")]
    [SerializeField] SoundManager m_sound_manager;
    [SerializeField] List<BulletSpawner> m_bullet_spawners;

    float m_fire_cooldown = 0f;

    private void OnEnable()
    {
        StartCoroutine(WeaponCooldownTask());
    }

    public void Shoot()
    {
        if (m_fire_cooldown > 0)
        {
            return;
        }
            foreach (BulletSpawner bullet_spawner in m_bullet_spawners)
        {
            bullet_spawner.SpawnBullet();
        }

        if (m_shoot_sfx != null)
        {
            m_sound_manager.PlaySFX(m_shoot_sfx);
        }


        m_fire_cooldown = m_fire_rate;
    }

    private IEnumerator WeaponCooldownTask()
    {
        while (true)
        {
            m_fire_cooldown -= Time.deltaTime;
            yield return null;
        }
    }
}
