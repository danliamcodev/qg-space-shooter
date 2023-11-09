using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupCollection : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] Power power;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PowerupCollector>(out PowerupCollector powerup_collector)) {
            power.ApplyToPlayer(powerup_collector.GetComponentInParent<Player>());
            this.gameObject.SetActive(false);
        }
    }
}
