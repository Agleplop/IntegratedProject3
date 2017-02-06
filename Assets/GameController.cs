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
	}

	IEnumerator EndGame ()
	{
		gameOverPanel.SetActive (true);
		yield return new WaitForSecondsRealtime (1.0f);
		SceneManager.LoadScene ("TestScene");
	}

}
