using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public GameLogic gameLogic;
    public Transform prefab;
    public Transform player;
    private List<Transform> chunks = new List<Transform>();

    public int renderDistance = 8;
    public int chunkLength = 16;

    void Start () {
        gameLogic = GameObject.Find("GameLogic").GetComponent<GameLogic>();

        Transform last = InstantiateChunk(this.transform.position, true);
        chunks.Add(last);

        for (int i = 0; i < renderDistance; i++)
        {
            last = InstantiateChunk(last.position + transform.forward * chunkLength, true);
            chunks.Add(last);
        }
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
        for (int i = 0; i < chunks.Count; i++)
        {
            Transform chunk = chunks[i];
            if(chunk.position.z < player.transform.position.z - chunkLength * renderDistance)
            {
                chunks.Remove(chunk);
                Destroy(chunk.gameObject);
                i--;
            } 
        }
    }

    Transform InstantiateChunk(Vector3 position, bool preRender = false)
    {
        Transform i = Instantiate(prefab, position, Quaternion.identity);
        if (!preRender)
            gameLogic.level++;
        return i;
    }
}
