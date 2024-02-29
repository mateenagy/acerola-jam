using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour
{
	Renderer _renderer;
	[SerializeField] PlayerTDSM player;
	[SerializeField] float drag;
	void Awake()
	{
		_renderer = GetComponent<Renderer>();
	}
	void Update()
	{
		_renderer.sharedMaterial.SetVector("_Direction", new Vector4(player.Rb.velocity.x * drag, player.Rb.velocity.y * drag, 0, 0));
	}
}
