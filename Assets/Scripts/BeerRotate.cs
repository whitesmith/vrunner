using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerRotate : MonoBehaviour {

	public int x = 0;
	public int y = 90;
	public int z = 15;
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (x, y, z) * Time.deltaTime);
	}
}