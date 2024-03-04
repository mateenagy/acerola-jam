using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    // Start is called before the first frame update
	public UnityEvent _event;
	public bool once = false;
	bool onceFinished = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnTriggerEnter2D(Collider2D col) {
		if (once && onceFinished)
		{
			return;
		}
		if (col.CompareTag("Player"))
		{
			_event.Invoke();
			if (once)
			{
				onceFinished = true;
			}
		}
	}
}
