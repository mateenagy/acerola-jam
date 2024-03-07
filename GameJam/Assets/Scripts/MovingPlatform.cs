using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
	public Transform start;
	public Transform end;
	public bool loop = true;
	public float speed = 1f;
	public GameObject player;
	public bool startOnTrigger = false;
	public bool isTriggered = false;
	bool isPlaying = false;

	void Start()
	{
		transform.position = start.position;
	}

	void Update()
	{
		if (startOnTrigger)
		{
			if (isTriggered)
			{
				if (!isPlaying)
				{
					StartCoroutine(MovePlatform());
				}
			}
		}
		else
		{
			if (!isPlaying)
			{
				StartCoroutine(MovePlatform());
			}
		}
	}


	IEnumerator MovePlatform()
	{
		isPlaying = true;
		yield return transform.DOMove(end.position, speed).SetEase(Ease.Linear).WaitForCompletion();
		if (loop)
		{
			yield return transform.DOMove(start.position, speed).SetEase(Ease.Linear).WaitForCompletion();
			isPlaying = false;
		}
	}

	public void StartPlatform()
	{
		isTriggered = true;
	}
	public void EndPlatform()
	{
		isTriggered = false;
	}
	void OnDrawGizmos()
	{
		if (start != null && end != null)
		{
			Gizmos.DrawLine(start.position, end.position);
		}
	}

	void OnDrawGizmosSelected()
	{
		if (start != null)
		{
			transform.position = start.position;
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("Enter");
		player.transform.SetParent(transform);
	}

	void OnCollisionExit2D(Collision2D collision)
	{
		Debug.Log("Exit");
		player.transform.SetParent(null);
	}
}
