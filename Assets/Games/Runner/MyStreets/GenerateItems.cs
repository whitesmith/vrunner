using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateItems : MonoBehaviour {

    public float probability = 0.1f;

    public float probabilityWater = 0.3f;

    public Transform beer;
    public Transform water;

    void Start () {
		for(int l = -1; l <= 1; l++)
        {
            for(int c = -6; c <= 5; c++)
            {
                if (UnityEngine.Random.Range(0, 100) < probability * 100) {
                    if (UnityEngine.Random.Range(0, 100) < probabilityWater * 100){
                        Instantiate(water, transform.position + new Vector3(l * 3.2f, 1, c * 2.5f + 1), Quaternion.identity);
                    }
                    else { 
                        Instantiate(beer, transform.position + new Vector3(l * 3.2f, 1, c * 2.5f + 1), Quaternion.identity);
                    }
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
