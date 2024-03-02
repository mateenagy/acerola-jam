using System.Collections.Generic;
public enum PlayerStates {
	Ground,
	Idle,
	Move,
	Jump,
	Fall
}
public class PlayerFactory : Factory<PlayerStates, PlayerState, PlayerSM>
{
	public PlayerFactory(PlayerSM sm) : base(sm)
	{
		States.Add(PlayerStates.Ground, new Ground(sm, this));
		States.Add(PlayerStates.Idle, new Idle(sm, this));
		States.Add(PlayerStates.Move, new Move(sm, this));
		States.Add(PlayerStates.Jump, new Jump(sm, this));
		States.Add(PlayerStates.Fall, new Fall(sm, this));
	}

	readonly Dictionary<PlayerStates, PlayerState> _States = new();
	public override Dictionary<PlayerStates, PlayerState> States => _States;
}
