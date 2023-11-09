using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupCollection : MonoBehaviour
{
    [Header("References")]
    [SerializeField] SoundManager m_sound_manager;

    [Header("Parameters")]
    [SerializeField] Power m_power;
    [SerializeField] AudioClip m_collection_sfx;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PowerupCollector>(out PowerupCollector powerup_collector)) {
            m_power.ApplyToPlayer(powerup_collector.GetComponentInParent<Player>());
            m_sound_manager.PlaySFX(m_collection_sfx);
            this.gameObject.SetActive(false);
        }
    }
}
