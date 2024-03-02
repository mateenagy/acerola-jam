using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTDGripped : PlayerTDState
{
	public PlayerTDGripped(PlayerTDSM stateMachine, PlayerTDFactory factory) : base(stateMachine, factory)
	{
		IsRoot = true;
	}

	public override void Enter()
	{
		base.Enter();
		Debug.Log("GRIPPED TO GLITCH");

		// Ctx.Rb.velocity = Vector2.zero;
	}

	public override void Update()
	{
		base.Update();
		if (Vector2.Distance(Ctx.transform.position, Ctx.GlitchPos.position) > 0.1f)
		{
			// Ctx.Rb.MovePosition(Time.deltaTime * (Ctx.transform.position - Ctx.GlitchPos.position));
			Ctx.transform.Rotate(Ctx.RotationSpeed * Time.deltaTime * new Vector3(0, 0, 1));
			// Ctx.transform.localScale = new(Ctx.transform.localScale.x - Time.deltaTime * 0.13f, Ctx.transform.localScale.y - Time.deltaTime * 0.13f);
			// Ctx.transform.position = Vector3.MoveTowards(Ctx.transform.position, Ctx.GlitchPos.position, Time.deltaTime * 5f);
		}
	}

	public override void FixedUpdate()
	{
		base.FixedUpdate();
		Ctx.Rb.DOMove(Ctx.GlitchPos.position, 1f);
		Ctx.StartCoroutine(ChangeScene());
	}

	IEnumerator ChangeScene() {
		yield return new WaitForSeconds(1f);
		Ctx.EEvents.Invoke();
	}
}
