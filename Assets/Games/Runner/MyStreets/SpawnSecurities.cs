using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSecurities : MonoBehaviour {

    public Transform prefab;
    public float delay = 5f;
	void Start () {
        Invoke("Spawn", delay);
    }
	
	void Spawn() {
        for (int l = -2; l <= 2; l++)
        {
            for (int c = -1; c <= 1; c++)
            {
                Instantiate(prefab, transform.position + new Vector3(l * 3.2f, 0.5f, c * 2.5f + 1), Quaternion.identity);
            }
        }
    }
}