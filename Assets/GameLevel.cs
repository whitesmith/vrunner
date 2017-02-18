using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ChunkProbability
{
    public Transform prefab;
    public float probability;
}

public class GameLevel : MonoBehaviour {

    public ChunkProbability[] prefabs;
    public Transform player;
    private List<Transform> chunks = new List<Transform>();

    public int renderDistance = 6;
    public int chunkLength = 16;

    void Start () {
        chunks.Add(InstantiateChunk(this.transform.position));
	}
	
	void Update () {
        GenerateChunks();
        ClearChunks();
    }

    void GenerateChunks()
    {
        Transform last = chunks[chunks.Count - 1];
        while(last.position.z < player.transform.position.z + chunkLength * renderDistance)
        {
            last = InstantiateChunk(last.position + transform.forward * chunkLength);
            chunks.Add(last);
        }
    }

    void ClearChunks()
    {
        foreach (Transform chunk in chunks)
        {
            if(chunk.position.z < player.transform.position.z - chunkLength * renderDistance)
            {
                Destroy(chunk.gameObject);
                chunks.Remove(chunk);
            } 
        }
    }

    Transform InstantiateChunk(Vector3 position)
    {
        Transform prefab;
        int val = UnityEngine.Random.Range(1, 100);

        if (val <= prefabs[1].probability * 100)
            prefab = prefabs[1].prefab;
        else
            prefab = prefabs[0].prefab;

        return Instantiate(prefab, position, Quaternion.identity);
    }
}
