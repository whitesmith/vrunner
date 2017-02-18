using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObstacles : MonoBehaviour {

    public Transform[] prefabs;
	// Use this for initialization
	void Start () {
        Transform prefab;
        int val = UnityEngine.Random.Range(1, 100);
        if (val <= 20) {
            prefab = prefabs[UnityEngine.Random.Range(0, prefabs.Length)];
            Transform obstacle = Instantiate(prefab, transform.position, Quaternion.identity);
            obstacle.transform.parent = gameObject.transform;
        }
	}
}
