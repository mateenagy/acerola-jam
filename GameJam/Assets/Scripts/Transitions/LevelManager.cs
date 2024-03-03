using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LevelManager : MonoBehaviour
{
	public static LevelManager Instance;
	public GameObject transitionContainer;
	[SerializeField] SceneTransition[] transitions;
	public int cloneUsage = 0;
	public int currentLevel = 0;
	public bool isStarted = false;
	public bool isDialog = true;
	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}
	void Start()
	{
		transitions = transitionContainer.GetComponentsInChildren<SceneTransition>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			LoadScene(SceneManager.GetActiveScene().name, "Fade");
		}
		if (Input.GetKeyDown(KeyCode.L))
		{
			isDialog = !isDialog;
		}
	}

	public void LoadScene(string sceneName, string transitionName)
	{
		StartCoroutine(LoadSceneAsync(sceneName, transitionName));
	}

	private IEnumerator LoadSceneAsync(string sceneName, string transitionName)
	{
		SceneTransition transition = transitions.First(t => t.name == transitionName);

		AsyncOperation scene = SceneManager.LoadSceneAsync(sceneName);
		scene.allowSceneActivation = false;
		yield return transition.TransitionEnter();
		do
		{
			yield return null;
		} while (scene.progress < 0.9f);
		scene.allowSceneActivation = true;

		yield return transition.TransitionLeave();
	}
}
