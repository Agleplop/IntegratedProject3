using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour 
{

	GameObject gameController;

	// Use this for initialization
	void Start () 
	{
		gameController = GameObject.FindGameObjectWithTag ("GameController");
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter (Collider other)
	{
		
		if (other.gameObject.tag == "Player")
		{
			GameController gcs = gameController.GetComponent<GameController> ();
			gcs.Hit ();
		}

	}

}
