using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnZoneExited : MonoBehaviour
{
    [Header("Actions")]
    [SerializeField] List<UnityEvent> m_on_zone_exited_actions;

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<ZoneDetector>(out ZoneDetector zoneDetector))
        {
            for (int i = 0; i < m_on_zone_exited_actions.Count; i++)
            {
                m_on_zone_exited_actions[i].Invoke();
            }
        }
    }
}
