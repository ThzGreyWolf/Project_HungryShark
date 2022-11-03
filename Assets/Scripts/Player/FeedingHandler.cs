using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FeedingHandler : MonoBehaviour {

    [SerializeField] string[] m_fishTags;

    [Space]
    [SerializeField] UnityEvent m_successEvent, m_failEvent;

    int m_checkIndex;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag(m_fishTags[m_checkIndex])) {
            m_successEvent?.Invoke();
        } else {
            m_failEvent?.Invoke();
        }

        SimplePool.Despawn(other.gameObject);
    }

    public void SetCheckIndex(int index) { m_checkIndex = index; }
}
