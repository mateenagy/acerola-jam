using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Glitch : MonoBehaviour
{
	[SerializeField] float radius;
	[SerializeField] string levelName;
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
			events.Invoke();
			StartCoroutine(ChangeScene());
		}
	}

	IEnumerator ChangeScene() {
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene(levelName);
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position, radius);
	}
}
