using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
	UIDocument ui;
    // Start is called before the first frame update
	public DialogSystem dialog;

	void Awake()
	{
		ui = GetComponent<UIDocument>();
	}
    void Start()
    {
		if (LevelManager.Instance.isStarted)
		{
			Destroy(gameObject);
			return;
		}
        Button play = ui.rootVisualElement.Q("MenuContainer").Q<Button>("Play");
		
		play.RegisterCallback<ClickEvent>(StartGame);
    }

	void StartGame(ClickEvent click)
	{
		LevelManager.Instance.isStarted = true;
		dialog.ShowDialog();
		Destroy(gameObject);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
