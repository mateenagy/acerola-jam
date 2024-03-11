using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalToSpace : MonoBehaviour
{
	public string level = "SpaceLevel";
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
			LevelManager.Instance.LoadScene(level, "Fade");
		}
	}
}
