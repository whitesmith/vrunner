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
    public float TimeStep = 3f;

    public string m_SceneToLoad;
    public AudioSource musicPlayer;

	void Start () {
		
	}
	
void Update() {
        if (Input.GetKeyDown(KeyCode.F1)) {
            if (Time.timeScale == 1.0F){
                Time.timeScale = 0.0F;
                musicPlayer.Pause();
            }
            else{
                Time.timeScale = 1.0F;
                musicPlayer.Play();
            }
            Time.fixedDeltaTime = Time.timeScale;
        }
    }

    public void gameOver()
    {
    	SceneManager.LoadScene(m_SceneToLoad, LoadSceneMode.Single);
    }
}
