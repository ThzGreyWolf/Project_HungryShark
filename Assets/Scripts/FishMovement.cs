using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour {
    
    [SerializeField] float m_speed;

    void FixedUpdate() {
        transform.Translate(Vector3.right * m_speed);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Despawn")) {
            SimplePool.Despawn(this.gameObject);
        }
    }
}
