using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkMovement : MonoBehaviour {
    
    [SerializeField] float m_minY, m_maxY;
    [SerializeField] float m_minX, m_maxX;
    [SerializeField] float m_speed;

    Vector2 m_target, m_startPos;

    void Start() {
        m_startPos = transform.position;
    }

    void Update() {
        m_target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate() {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(Mathf.Clamp(m_target.x, m_minX, m_maxX), Mathf.Clamp(m_target.y, m_minY, m_maxY)), m_speed * Time.fixedDeltaTime);
    }

    public void Reset() {
        transform.position = m_startPos;
    }
}
