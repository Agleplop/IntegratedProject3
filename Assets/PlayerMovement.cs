using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{

	bool grounded;
	float jumpPower = 0.4f;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Physics.Raycast (transform.position, Vector3.down, 1.5f))
		{
			grounded = true;
			jumpPower = 0.4f;
		}

		if (Input.GetButtonDown ("Jump") && grounded)
		{
			print ("hello");

			grounded = false;
		}

		if (!grounded)
		{
			transform.Translate (Vector3.up * jumpPower);
			jumpPower -= 0.02f;
		}
			

		if (grounded)
		{
			if (Input.GetAxis ("Horizontal") > 0 && transform.position.x < 1.6)
			{
				transform.Translate (new Vector3 (0.1f, 0, 0));
			}

			if (Input.GetAxis ("Horizontal") < 0 && transform.position.x > -1.6)
			{
				transform.Translate (new Vector3 (-0.1f, 0, 0));
			}

		}
			


	}

}
