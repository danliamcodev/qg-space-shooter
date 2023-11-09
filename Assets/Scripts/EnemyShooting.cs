using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Weapon m_active_weapon;

    bool m_shooting_activated = false;

    private void Start()
    {
        StartCoroutine(DetectShootInputTask());
    }

    public void OnZoneEntered()
    {
        Invoke(nameof(ActivateShooting), 1f);
    }

    public void OnZoneExited()
    {
        m_shooting_activated = false;
    }

    private void ActivateShooting()
    {
        m_shooting_activated = true;
        print("Shooting activated");
    }

    private IEnumerator DetectShootInputTask()
    {
        while (true)
        {
            m_active_weapon.transform.rotation = Quaternion.Euler(0, 0, 180f);

            if (m_shooting_activated)
            {
                m_active_weapon.Shoot();
            }
            yield return null;
        }
    }
}
