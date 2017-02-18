using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;

namespace VRStandardAssets.Utils
{
	public class ItemStart : MonoBehaviour {

		[SerializeField] private SelectionSlider m_SelectionSlider;
		[SerializeField] private string m_SceneToLoad;

		private void OnEnable () 	{
	        m_SelectionSlider.OnBarFilled += HandleOnBarFilled;
	    }


	    private void OnDisable () {
	        m_SelectionSlider.OnBarFilled -= HandleOnBarFilled;
	    }

		
		void HandleOnBarFilled () {
			// Load the level.
	        SceneManager.LoadScene(m_SceneToLoad, LoadSceneMode.Single);
		}

	}
}