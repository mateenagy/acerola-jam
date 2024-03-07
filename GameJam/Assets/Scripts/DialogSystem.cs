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

	void Awake()
	{
		if (!showOnStart)
		{
			dialog.SetActive(false);
		}
	}
	void Start()
	{
		if (showOnStart)
		{
			label = ui.rootVisualElement.Q("DialogContainer").Q<Label>("Dialog");
			label.text = lines[index];
			LevelManager.Instance.isDialog = true;
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (!LevelManager.Instance.isDialog)
		{
			Time.timeScale = 1;
			return;
		}

		Time.timeScale = 0;
		if (ui.rootVisualElement != null)
		{
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
				dialog.SetActive(false);
				LevelManager.Instance.isDialog = false;
				Time.timeScale = 1;
				return;
			}
		}

	}

	public void ShowDialog()
	{
		dialog.SetActive(true);
		LevelManager.Instance.isDialog = true;
	}
}
