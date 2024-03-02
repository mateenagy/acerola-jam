using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UITransition : MonoBehaviour
{
	VisualElement root;
	VisualElement BoxTransition;

	void Start()
	{
		root = GetComponent<UIDocument>().rootVisualElement;
		BoxTransition = root.Q<VisualElement>("BoxTransition");
	}

	public void TranstionEnter()
	{
		BoxTransition.RemoveFromClassList("test");
		BoxTransition.AddToClassList("transition-enter");
	}
	void TranstionExit()
	{
		BoxTransition.RemoveFromClassList("test");
		BoxTransition.AddToClassList("transition-enter");
	}

	// Update is called once per frame
	void Update()
	{

	}
}
