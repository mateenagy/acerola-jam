using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerTDStates
{
    Move,
	Gripped,
}
public class PlayerTDFactory : Factory<PlayerTDStates, PlayerTDState, PlayerTDSM>
{
    Dictionary<PlayerTDStates, PlayerTDState> _States = new();
    public override Dictionary<PlayerTDStates, PlayerTDState> States => _States;
    public PlayerTDFactory(PlayerTDSM sm) : base(sm)
    {
        States.Add(PlayerTDStates.Move, new PlayerTDMove(sm, this));
        States.Add(PlayerTDStates.Gripped, new PlayerTDGripped(sm, this));
    }
}
