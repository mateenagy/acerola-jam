using UnityEngine;

public class Move : PlayerState
{
	public Move(PlayerSM stateMachine, PlayerFactory factory) : base(stateMachine, factory) { }

	public override void Enter()
	{
		base.Enter();
		Debug.Log("Move");
	}
	public override void Update()
	{
		base.Update();
		Ctx.Rb.velocity = new(Ctx.InputX * Ctx.Speed, Ctx.Rb.velocity.y);
		CheckSwitchState();
	}
	public override void CheckSwitchState()
	{
		base.CheckSwitchState();
		if (!Ctx.IsMoving)
		{
			SwitchState(Factory.States[PlayerStates.Idle]);
		}
	}
}
