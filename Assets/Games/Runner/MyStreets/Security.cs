using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Security : MonoBehaviour {

    public float speed = 2f;
    GameObject player;

	void Start () {
        player = GameObject.Find("Player");
    }
	
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);
        transform.LookAt(player.transform);
    }
}
