using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtHandler : MonoBehaviour {

    [SerializeField] Transform m_thoughBubbleParent;
    [SerializeField] Transform m_thoguhtPos;

    [Space]
    [SerializeField] Transform m_thought;
    [SerializeField] Sprite[] m_thoguhts;

    [Space]
    [SerializeField] float m_thoughtFlipY;

    [Space]
    [SerializeField] float m_thoughtChangeInterval;

    float m_currentthoughtChangeInterval;

    FeedingHandler m_feedingHandler;

    void Start() {
        m_feedingHandler = GetComponent<FeedingHandler>();
    }

    void Update() {
        KeepThoguhtBubbleVisible();

        m_currentthoughtChangeInterval -= Time.deltaTime;
        if(m_currentthoughtChangeInterval <= 0f) {
            PickNextMeal(Random.Range(0, m_thoguhts.Length));
            m_currentthoughtChangeInterval = m_thoughtChangeInterval;
        }
    }

    void KeepThoguhtBubbleVisible() {
        if(transform.position.y > m_thoughtFlipY) {
            m_thoughBubbleParent.localScale = new Vector2(1, -1);
        } else if(transform.position.y < -m_thoughtFlipY) {
            m_thoughBubbleParent.localScale = new Vector2(1, 1);
        }

        m_thought.position = m_thoguhtPos.position;
    }

    void PickNextMeal(int index) {
        m_thought.GetComponent<SpriteRenderer>().sprite = m_thoguhts[index];
        m_feedingHandler.SetCheckIndex(index);
    }
}
