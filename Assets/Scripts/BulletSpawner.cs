using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [Header("References")]
    public PlayerBullet m_prefab_player_bullet;

    public void SpawnBullet() {
        PlayerBullet bullet = Instantiate(m_prefab_player_bullet);
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
    }
}
