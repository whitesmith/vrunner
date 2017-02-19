using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSecurities : MonoBehaviour {

    private GameObject player;
    public Transform prefab;
    private bool generated = false;

	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (generated)
            return;

        if (transform.position.z < player.transform.position.z - 15)
        {
            Instantiate(prefab, transform.position + Vector3.right * 8 - Vector3.forward * 2, Quaternion.identity);
            Instantiate(prefab, transform.position - Vector3.right * 8 - Vector3.forward * 2, Quaternion.identity);
            generated = true;
        }
            


    }
}
