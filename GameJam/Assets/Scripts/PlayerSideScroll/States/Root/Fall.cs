using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : PlayerState
{
	public Fall(PlayerSM stateMachine, PlayerFactory factory) : base(stateMachine, factory)
	{
		IsRoot = true;
	}

	public override void Enter()
	{
		base.Enter();
		Ctx.Animator.SetBool("isJumping", false);
		Ctx.Animator.SetBool("isFall", true);
		Debug.Log("Enter");
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

	public override void Exit()
	{
		base.Exit();
		Ctx.IsJumping = false;
		Ctx.Animator.SetBool("isFall", false);
	}

	public override void CheckSwitchState()
	{
		base.CheckSwitchState();
		if (Ctx.IsGrounded)
		{
			SwitchState(Factory.States[PlayerStates.Ground]);
		}
	}
}
