using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] ObjectPoolController m_bullet_pool_controller;

    public void SpawnBullet() {
        GameObject bullet = m_bullet_pool_controller.GetObject();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
        bullet.SetActive(true);
    }
}
