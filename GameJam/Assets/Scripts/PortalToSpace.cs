using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalToSpace : MonoBehaviour
{
	void Start()
	{

	}

	void Update()
	{

	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("Player"))
		{
			LevelManager.Instance.currentLevel += 1;
			LevelManager.Instance.LoadScene("SpaceLevel", "Fade");
		}
	}
}
