using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour {

    public int level = 0;

    public int Score;

    public float Drunkness;
    public float StartDrunk = 50f;
    public float End = 100f;
    public float BeerStep = 10f;
    public float WaterStep = 5f;
    public float TimeStep = 10f;

    public string m_SceneToLoad;

	void Start () {
		
	}
	
	void Update () {
		
	}

    public void gameOver()
    {
    	SceneManager.LoadScene(m_SceneToLoad, LoadSceneMode.Single);
    }
}
