using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : PlayerState
{
	public Jump(PlayerSM stateMachine, PlayerFactory factory) : base(stateMachine, factory)
	{
		IsRoot = true;
	}

	public override void Enter()
	{
		base.Enter();
		Ctx.JumpSound.Play();
		Ctx.Rb.velocity = new(Ctx.Rb.velocity.x, Ctx.JumpHeight);
		InitialSubState();
	}

	public override void InitialSubState()
	{
		base.InitialSubState();
		if (Ctx.IsMoving)
		{
			SetSubState(Factory.States[PlayerStates.Move]);
		}
		else
		{
			SetSubState(Factory.States[PlayerStates.Idle]);
		}
	}

	public override void Update()
	{
		base.Update();
		CheckSwitchState();
	}

	public override void CheckSwitchState()
	{
		base.CheckSwitchState();
		if (!Ctx.IsGrounded && Ctx.IsFall)
		{
			SwitchState(Factory.States[PlayerStates.Fall]);
		}
		if (Ctx.IsGrounded)
		{
			SwitchState(Factory.States[PlayerStates.Ground]);
		}
	}
}
