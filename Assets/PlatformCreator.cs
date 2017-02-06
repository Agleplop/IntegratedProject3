using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCreator : MonoBehaviour 
{
	List<GameObject> platformList = new List<GameObject>();
	public GameObject[] platform = new GameObject[2];

	// Use this for initialization
	void Start () 
	{
		GameObject platformObject = Instantiate(platform[0], new Vector3(transform.position.x, transform.position.y, transform.position.z - 5), Quaternion.identity) as GameObject;
		platformList.Add (platformObject);

		for (int i = 0; i < 4; i++)
		{
			platformObject = Instantiate(platform[0], new Vector3(platformList[0].transform.position.x, platformList[0].transform.position.y, platformList[0].transform.position.z + 10 * (i + 1)), 
				Quaternion.identity) as GameObject;

			platformList.Add (platformObject);
		}

	}
	
	// Update is called once per frame
	void Update () 
	{

		foreach (GameObject p in platformList)
		{
			p.transform.Translate (new Vector3 (0, 0, -0.2f));

			if (p.transform.position.z < -10)
			{
				Destroy (platformList[0]);

				platformList.RemoveAt (0);

				GameObject l = platformList[platformList.Count - 1];

				GameObject platformObject = Instantiate(platform[Random.Range (0, 2)], new Vector3(transform.position.x, transform.position.y, transform.position.z + 25), Quaternion.identity) as GameObject;
				platformList.Add (platformObject);

				return;

			}

		}

		print (platformList.Count);

	}

}
