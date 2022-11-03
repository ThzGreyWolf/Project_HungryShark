using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour {
    
    [SerializeField] FishScriptableObject[] m_fishToSpawn;
    [SerializeField] int m_poolSize = 10;

    [Space]
    [SerializeField] float m_spawnX;

    [Space]
    [SerializeField] float m_spawnInterval;

    float m_currentInterval = 0;

    void Start() {
        foreach(FishScriptableObject fish in m_fishToSpawn) {
            SimplePool.Preload(fish.prefab, m_poolSize);
        }
    }

    void Update() {
        m_currentInterval -= Time.deltaTime;
        if(m_currentInterval <= 0f) {
            FishScriptableObject fish = m_fishToSpawn[Random.Range(0, m_fishToSpawn.Length)];
            SimplePool.Spawn(fish.prefab, new Vector3(m_spawnX, Random.Range(fish.spawnMinY, fish.spawnMaxY), 0f), Quaternion.identity);

            m_currentInterval = m_spawnInterval;
        }
    }
}
