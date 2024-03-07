using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
	public Transform start;
	public Transform end;
	public float speed = 2f;
	bool isPlaying = false;
	void Start()
	{
		transform.position = start.position;
	}

	void Update()
	{
		if (!isPlaying)
		{
			StartCoroutine(MovePlatform());
		}
	}

	IEnumerator MovePlatform()
	{
		isPlaying = true;
		yield return transform.DOMove(end.position, speed).SetEase(Ease.Linear).WaitForCompletion();
		yield return transform.DOMove(start.position, speed).SetEase(Ease.Linear).WaitForCompletion();
		isPlaying = false;
	}


	void OnDrawGizmosSelected()
	{
		if (start != null)
		{
			transform.position = start.position;
		}
	}
	void OnDrawGizmos()
	{
		if (start != null && end != null)
		{
			Gizmos.DrawLine(start.position, end.position);
			// transform.position = start.position;
		}
	}
}
