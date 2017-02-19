using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateItems : MonoBehaviour {

    public float probability = 0.1f;
    public Transform prefab;
    void Start () {
		for(int l = -1; l <= 1; l++)
        {
            for(int c = -6; c <= 5; c++)
            {
                int val = UnityEngine.Random.Range(0, 100);
                if (val < probability * 100)
                    Instantiate(prefab, transform.position + new Vector3(l * 3.2f, 1, c * 2.5f + 1), Quaternion.identity);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
