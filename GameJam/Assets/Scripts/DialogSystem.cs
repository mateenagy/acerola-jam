using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class DialogSystem : MonoBehaviour
{
	public string[] lines;
	public GameObject dialog;
	int index = 0;
	public UIDocument ui;
	public bool showOnStart = false;
	public AudioSource stepSound;
	Label label;
	// Start is called before the first frame update
	void Start()
	{
		label = ui.rootVisualElement.Q("DialogContainer").Q<Label>("Dialog");
		label.text = lines[index];

		if (showOnStart)
		{
			LevelManager.Instance.isDialog = true;
		}
	}

	void OnEnable()
	{
	}

	// Update is called once per frame
	void Update()
	{
		dialog.SetActive(LevelManager.Instance.isDialog);
		if (!LevelManager.Instance.isDialog)
		{
			Time.timeScale = 1;
			return;
		}

		Time.timeScale = 0;

		label = ui.rootVisualElement.Q("DialogContainer").Q<Label>("Dialog");

		if (Input.GetKeyDown(KeyCode.Return))
		{
			index += 1;
			stepSound.Play();
		}

		if (index <= lines.Length - 1)
		{
			label.text = lines[index];
		}
		else
		{
			stepSound.Play();
			index = 0;
			LevelManager.Instance.isDialog = false;
			Time.timeScale = 1;
			return;
		}
	}

	public void ShowDialog()
	{
		LevelManager.Instance.isDialog = true;
	}
}
