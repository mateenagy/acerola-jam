using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Glitch : MonoBehaviour
{
	[SerializeField] float radius;
	[Header("Scene loader")]
	[SerializeField] string sceneName;
	[SerializeField] string transition;
	[SerializeField] UnityEvent events;
	bool isTransition = false;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		RaycastHit2D hit = Physics2D.CircleCast(transform.position, radius, Vector2.zero);

		if (hit.collider && !isTransition)
		{
			isTransition = true;
			events.Invoke();
			StartCoroutine(ChangeScene());
		}
	}

	IEnumerator ChangeScene() {
		yield return new WaitForSeconds(1f);
		LevelManager.Instance.LoadScene(sceneName, transition);
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position, radius);
	}
}
