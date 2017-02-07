using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{

	bool grounded;
	float jumpPower = 0.4f;

	Vector2 touchOrigin = new Vector2 (0, 0);
	Vector3 target;

	// Use this for initialization
	void Start () 
	{
		target = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		float horizontal = 0;
		int vertical = 0;

		//horizontal = (int)(Input.GetAxisRaw ("Horizontal"));
		//vertical = (int) (Input.GetAxisRaw ("Vertical"));

		if (Input.touchCount > 0)
		{
			Touch myTouch = Input.touches[0];

			if (myTouch.phase == TouchPhase.Began)
			{
				touchOrigin = myTouch.position;
			}

			else if (myTouch.phase == TouchPhase.Ended && touchOrigin.x >= 0)
			{
				Vector2 touchEnd = myTouch.position;

				float x = touchEnd.x - touchOrigin.x;

				float y = touchEnd.y - touchOrigin.y;

				touchOrigin.x = -1;

				vertical = y > 0 ? 1 : 0;
				/*
				if (Mathf.Abs (x) > Mathf.Abs (y))
					horizontal = x > 0 ? 1: -1;
				else
					vertical = y > 0 ? 1 : 0;
				*/
			}

		}

		horizontal = Input.acceleration.x;

		RaycastHit hit;

		Physics.Raycast (transform.position, Vector3.down, out hit, 1.5f);

		if (hit.collider != null && hit.collider.gameObject.tag == "Ground")
		{
			grounded = true;
			jumpPower = 0.4f;
		}



			if (vertical > 0 && grounded)
			{
				print ("hello");

				grounded = false;
			}

//			if (grounded)
//			{
//				if (horizontal > 0 && transform.position.x < 1.6)
//				{	
//					transform.Translate (Vector3.right * 0.2f);
//				}
//
//				if (horizontal < 0 && transform.position.x > -1.6)
//				{
//					transform.Translate (Vector3.left * 0.2f);
//				}
//
//			}

		if (grounded)
		{
			if (horizontal > 0.1f)
			{
				if (transform.position.x + horizontal < 1.6f)
				{
					transform.Translate (horizontal / 2, 0, 0);
				}
				else
				{
					transform.position = new Vector3 (1.6f, 1.9f, -4.5f);
				}
			}

			if (horizontal < -0.1f)
			{
				if (transform.position.x - horizontal > -1.3f)
				{
					transform.Translate (horizontal / 2, 0, 0);
				}
				else
				{
					transform.position = new Vector3 (-1.6f, 1.9f, -4.5f);
				}
			}


		}
			
		print (target.x);

		if (!grounded)
		{
			transform.Translate (Vector3.up * jumpPower);
			jumpPower -= 0.02f;
		}
			

	}
		
}
