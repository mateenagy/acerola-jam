using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Fade : SceneTransition
{
	UIDocument ui;
	VisualElement root;
	public override IEnumerator TransitionEnter()
	{
		root.RemoveFromClassList("fade--leave");
		root.AddToClassList("fade--enter");
		yield return new WaitForSeconds(1f);
	}

	public override IEnumerator TransitionLeave()
	{
		root.RemoveFromClassList("fade--enter");
		root.AddToClassList("fade--leave");
		yield return new WaitForSeconds(1f);
	}

	// Start is called before the first frame update
	void Awake()
	{
		ui = GetComponent<UIDocument>();
		root = ui.rootVisualElement;
	}

	// Update is called once per frame
	void Update()
	{

	}
}
