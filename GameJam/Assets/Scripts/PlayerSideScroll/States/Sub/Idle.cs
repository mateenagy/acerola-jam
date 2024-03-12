using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : PlayerState
{
	public Idle(PlayerSM stateMachine, PlayerFactory factory) : base(stateMachine, factory) { }

	public override void Enter()
	{
		base.Enter();
		Ctx.Animator.SetBool("IsMoving", false);
	}
	public override void Update()
	{
		base.Update();

		CheckSwitchState();
	}
	public override void Exit()
	{
		base.Exit();
		Ctx.Animator.SetBool("isJumping", false);
	}
	public override void CheckSwitchState()
	{
		base.CheckSwitchState();
		if (Ctx.IsMoving)
		{
			SwitchState(Factory.States[PlayerStates.Move]);
		}
	}
}
