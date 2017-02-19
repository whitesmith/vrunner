using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObstacles : MonoBehaviour {

    public Transform prefab;
    private int level;

	void Start () {
        level = GameObject.Find("GameLogic").GetComponent<GameLogic>().level;

        int val = UnityEngine.Random.Range(level/5, 5);
        if (val < 4 || level == 0)
            return;

        int lane = UnityEngine.Random.Range(-1, 2);
        Transform a = Instantiate(prefab, transform.position + Vector3.right*lane*3.2f, Quaternion.identity);
        a.eulerAngles = new Vector3(0, 180, 0);
	}
}
