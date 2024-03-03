using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerUI : MonoBehaviour
{
	UIDocument ui;
	public VisualTreeAsset playerIcon;

	void Start()
	{
		ui = GetComponent<UIDocument>();
		Label label = ui.rootVisualElement.Q("TopPart").Q<Label>("Counter");
		label.text = "x " + LevelManager.Instance.cloneUsage;
		// for (int i = 0; i < LevelManager.Instance.cloneUsage; i++)
		// {
		// 	Debug.Log(LevelManager.Instance.cloneUsage);
		// 	TemplateContainer iconContainer = playerIcon.Instantiate();
		// 	ui.rootVisualElement.Q("TopPart").Add(iconContainer);
		// }
	}

	public void RemoveIcon()
	{
		Label label = ui.rootVisualElement.Q("TopPart").Q<Label>("Counter");
		label.text = "x " + LevelManager.Instance.cloneUsage;
		// TemplateContainer iconContainer = playerIcon.Instantiate();
		// ui.rootVisualElement.Q("TopPart").RemoveAt(0);
	}
}
