using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fish", menuName = "ScriptableObjects/FishScriptableObject", order = 1)]
public class FishScriptableObject : ScriptableObject {
    public GameObject prefab;

    public float spawnMinY, spawnMaxY;
}
