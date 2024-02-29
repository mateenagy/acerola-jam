using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Glitch : MonoBehaviour
{
	[SerializeField] float radius;
	[SerializeField] UnityEvent events;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		RaycastHit2D hit = Physics2D.CircleCast(transform.position, radius, Vector2.zero);

		if (hit.collider )
		{
			Debug.Log("Collide");
			events.Invoke();
		}
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position, radius);
	}
}
