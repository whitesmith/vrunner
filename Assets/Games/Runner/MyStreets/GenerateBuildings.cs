using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBuildings : MonoBehaviour {

    public Transform[] prefabs;

	void Start () {
        Transform building;

        building = InstantiateBuilding();
        building.position += new Vector3(11, 0, -10);
        building.eulerAngles = new Vector3(0, 90, 0);

        building = InstantiateBuilding();
        building.position += new Vector3(11, 0, 5);
        building.eulerAngles = new Vector3(0, 90, 0);

        building = InstantiateBuilding();
        building.position += new Vector3(-11, 0, -10);
        building.eulerAngles = new Vector3(0, -90, 0);

        building = InstantiateBuilding();
        building.position += new Vector3(-11, 0, 5);
        building.eulerAngles = new Vector3(0, -90, 0);

    }
	
	Transform InstantiateBuilding()
    {
        Transform prefab = prefabs[UnityEngine.Random.Range(0, prefabs.Length - 1)];
        Transform building = Instantiate(prefab, transform.position, Quaternion.identity);
        building.transform.parent = gameObject.transform;
        return building;
    }
}
