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
	}

	public void RemoveIcon()
	{
		Label label = ui.rootVisualElement.Q("TopPart").Q<Label>("Counter");
		label.text = "x " + LevelManager.Instance.cloneUsage;
	}
}
