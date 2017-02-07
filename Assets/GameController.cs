using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour 
{

	public GameObject gameOverPanel;

	public void Hit ()
	{
		StartCoroutine (EndGame ());
		Screen.autorotateToLandscapeLeft = false;
		Screen.autorotateToLandscapeRight = false;
		Screen.autorotateToPortraitUpsideDown = false;
	}

	IEnumerator EndGame ()
	{
		gameOverPanel.SetActive (true);
		yield return new WaitForSecondsRealtime (1.0f);
		SceneManager.LoadScene ("TestScene");
	}

}
