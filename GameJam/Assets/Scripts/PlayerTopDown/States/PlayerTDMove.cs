using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTDMove : PlayerTDState
{
	bool isPlaying = false;
    public PlayerTDMove(PlayerTDSM stateMachine, PlayerTDFactory factory) : base(stateMachine, factory)
    {
        IsRoot = true;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        Ctx.transform.Rotate(-Ctx.InputX * Ctx.RotationSpeed * Time.deltaTime * new Vector3(0, 0, 1));

		CheckSwitchState();
    }

	public override void FixedUpdate()
	{
		base.FixedUpdate();
		if (Ctx.InputY != 0)
        {
			if (!isPlaying)
			{
				Ctx.ship.Play();
				isPlaying = true;
			}
            Ctx.Rb.AddForce(Ctx.InputY * Ctx.Speed * Ctx.transform.up, ForceMode2D.Impulse);
        } else {
			Ctx.ship.Pause();
			isPlaying = false;
		}
	}

	public override void Exit()
	{
		base.Exit();
		Ctx.ship.Pause();
		isPlaying = false;
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
