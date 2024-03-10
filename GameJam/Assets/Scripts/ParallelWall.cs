using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallelWall : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag("Player"))
		{
			Debug.Log("Enter");
			LevelManager.Instance.insideWall = true;
			gameObject.layer = 0;
		}
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.CompareTag("Player"))
		{
			Debug.Log("Exit");
			LevelManager.Instance.insideWall = false;
			gameObject.layer = 7;
		}
	}
}
