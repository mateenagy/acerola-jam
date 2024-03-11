using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
	UIDocument ui;
	public GameObject player;
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
		player.SetActive(false);
        Button play = ui.rootVisualElement.Q("MenuContainer").Q<Button>("Play");
		
		play.RegisterCallback<ClickEvent>(StartGame);
    }

	void StartGame(ClickEvent click)
	{
		player.SetActive(true);
		LevelManager.Instance.isStarted = true;
		dialog.ShowDialog();
		Destroy(gameObject);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
