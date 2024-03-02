public class PlayerState : IState<PlayerSM, PlayerFactory>
{
	public PlayerState(PlayerSM stateMachine, PlayerFactory factory) : base(stateMachine, factory)
	{
		Ctx = stateMachine;
		Factory = factory;
	}

	protected override void SwitchState(IState<PlayerSM, PlayerFactory> newState)
	{
		base.SwitchState(newState);
		if (IsRoot)
		{
			Ctx.CurrentState = (PlayerState)newState;
		}
		else
		{
			CurrentSuperState?.SetSubState(newState);
		}
	}
}
