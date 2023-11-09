using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] VoidEvent m_player_died;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerBullet>(out PlayerBullet bullet))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        print("player died");
        m_player_died.Raise();
    }
}
