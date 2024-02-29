using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerTDState : IState<PlayerTDSM, PlayerTDFactory>
{
    public PlayerTDState(PlayerTDSM stateMachine, PlayerTDFactory factory) : base(stateMachine, factory)
    {
        Ctx = stateMachine;
        Factory = factory;
    }

    protected override void SwitchState(IState<PlayerTDSM, PlayerTDFactory> newState)
    {
        base.SwitchState(newState);
        if (IsRoot)
        {
            Ctx.CurrentState = (PlayerTDState)newState;
        } else {
            CurrentSuperState.SetSubState(newState);
        }
    }
}
