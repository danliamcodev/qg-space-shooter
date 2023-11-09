using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnZoneEntered : MonoBehaviour
{
    [Header("Actions")]
    [SerializeField] List<UnityEvent> m_on_zone_entered_actions;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ZoneDetector>(out ZoneDetector zoneDetector))
        {
            for (int i = 0; i < m_on_zone_entered_actions.Count; i++)
            {
                m_on_zone_entered_actions[i].Invoke();
            }
        }
    }
}
