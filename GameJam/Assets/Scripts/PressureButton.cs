using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PressureButton : MonoBehaviour
{
	SpriteRenderer spriteRenderer;
	bool isClonePressed = false;
	public GameObject target;
	public UnityEvent openEvent;
	public UnityEvent closeEvent;
	public Sprite on;
	public Sprite off;

	void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("Player"))
		{
			openEvent.Invoke();
			spriteRenderer.sprite = on;
		}

		if (col.CompareTag("Clone"))
		{
			spriteRenderer.sprite = on;
			isClonePressed = true;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.CompareTag("Player") && !isClonePressed)
		{
			spriteRenderer.sprite = off;
			closeEvent.Invoke();
		}
	}
	void OnDrawGizmosSelected()
	{
		if (target)
		{
			Gizmos.color = Color.white;
			Gizmos.DrawLine(transform.position, target.transform.position);
		}
	}
}
