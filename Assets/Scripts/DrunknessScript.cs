using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class DrunknessScript : MonoBehaviour {
    public Slider m_Slider;
    public Transform camera;

    private GameLogic gameLogic;
    private BlurOptimized blur;


    private void OnEnable () {
        gameLogic = GameObject.Find("GameLogic").GetComponent<GameLogic>();
        blur = camera.GetComponent<BlurOptimized>();

        gameLogic.Drunkness = gameLogic.StartDrunk;
        SetSliderValue(gameLogic.StartDrunk / gameLogic.End);
    }

    private void Update () {
        if (Input.GetKeyDown("s")) {
            gameLogic.Drunkness += gameLogic.BeerStep;
            gameLogic.Score += 1;
        }
        if (Input.GetKeyDown("a")) {
            gameLogic.Drunkness -= gameLogic.WaterStep;
        }

        gameLogic.Drunkness -= Time.deltaTime * gameLogic.TimeStep; 
        FillBar();
    }

    private void FillBar () {
        if (gameLogic.Drunkness >= gameLogic.End || gameLogic.Drunkness <= 0) {
            PlayerPrefs.SetInt("Score", gameLogic.Score);
            gameLogic.gameOver();
        }

        if(gameLogic.Drunkness >= 50) {
            blur.blurSize = gameLogic.Drunkness / 40;
        }
        else {
            blur.blurSize = 0;
        }

        
        SetSliderValue(gameLogic.Drunkness / gameLogic.End);
    }


    private void SetSliderValue (float sliderValue) {
        if (m_Slider)
            m_Slider.value = sliderValue;
    }
}