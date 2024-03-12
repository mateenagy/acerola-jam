using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : PlayerState
{
	public Ground(PlayerSM stateMachine, PlayerFactory factory) : base(stateMachine, factory)
	{
		IsRoot = true;
	}

	public override void Enter()
	{
		base.Enter();
		Ctx.IsJumping = false;
		InitialSubState();
	}

	public override void InitialSubState()
	{
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
		if (!Ctx.IsGrounded && !Ctx.IsJumping && Ctx.IsFall)
		{
			SwitchState(Factory.States[PlayerStates.Fall]);
		}
		if (Ctx.IsGrounded && Ctx.IsJumping)
		{
			SwitchState(Factory.States[PlayerStates.Jump]);
		}
	}
}
