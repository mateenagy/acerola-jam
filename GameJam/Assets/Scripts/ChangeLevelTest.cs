using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevelTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Y))
		{
			LevelManager.Instance.LoadScene("Level1", "Fade");
		}
        
    }
}
