using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTDMove : PlayerTDState
{
    public PlayerTDMove(PlayerTDSM stateMachine, PlayerTDFactory factory) : base(stateMachine, factory)
    {
        IsRoot = true;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("MOVE");
    }

    public override void Update()
    {
        base.Update();
        if (Ctx.InputY != 0)
        {
            Ctx.Rb.AddForce(Ctx.InputY * Ctx.Speed * Ctx.transform.up, ForceMode2D.Impulse);
        }
        Ctx.transform.Rotate(-Ctx.InputX * Ctx.RotationSpeed * Time.deltaTime * new Vector3(0, 0, 1));

		CheckSwitchState();
    }

	public override void CheckSwitchState()
	{
		base.CheckSwitchState();
		if (Ctx.IsGripped)
		{
			SwitchState(Factory.States[PlayerTDStates.Gripped]);
		}
	}
}
