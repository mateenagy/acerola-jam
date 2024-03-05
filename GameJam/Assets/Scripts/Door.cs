using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Vector2 openPosition;
    Vector2 closePosition;
    void Start()
    {
        closePosition = transform.position;
    }

	public void Open()
	{
		transform.DOMove(openPosition, 2f);
	}

	public void Close()
	{
		transform.DOMove(closePosition, 2f);
	}
}
