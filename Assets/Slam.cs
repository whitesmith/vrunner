using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slam : MonoBehaviour {

    private bool reloading = false;
	
	void Update () {
        if (reloading)
        {
            this.transform.position = this.transform.position + this.transform.up * 5 * Time.deltaTime;
            if (this.transform.position.y >= 10) reloading = false;
        }
        else
        {
            this.transform.position = this.transform.position - this.transform.up * 50 * Time.deltaTime;
            if (this.transform.position.y <= 2) reloading = true;
        }
            
    }
}
