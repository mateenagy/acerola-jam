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
	Label label;
	// Start is called before the first frame update
	void Start()
	{
		label = ui.rootVisualElement.Q("DialogContainer").Q<Label>("Dialog");
		Debug.Log(label.text);
		label.text = lines[index];
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
			return;
		}

		label = ui.rootVisualElement.Q("DialogContainer").Q<Label>("Dialog");

		if (Input.GetKeyDown(KeyCode.Space))
		{
			index += 1;
		}

		if (index <= lines.Length - 1)
		{
			label.text = lines[index];
		}
		else
		{
			index = 0;
			LevelManager.Instance.isDialog = false;
			return;
		}
	}
}
