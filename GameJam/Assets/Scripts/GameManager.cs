using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager manager;
	public static int currentGlitch = 0;
    // Start is called before the first frame update
    void Start()
    {
		if (manager == null)
		{
			manager = this;
		} else {
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
        
    }
}
