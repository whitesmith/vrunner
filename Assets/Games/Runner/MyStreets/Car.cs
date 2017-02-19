using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int intensity = UnityEngine.Random.Range(100000, 150000);

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward * -intensity);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
