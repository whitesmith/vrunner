using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {
	public Text m_TextComponent;

	// Use this for initialization
	void Start () {
		m_TextComponent.text = "Score: <b>" + PlayerPrefs.GetInt("Score") + "</b>";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
