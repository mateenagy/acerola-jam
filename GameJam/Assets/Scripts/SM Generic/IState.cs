public interface ITest<T>
{
	T CurrentState { get; set; }
}

public abstract class IState<T, F> 
{
	private bool isRoot = false;
	protected virtual IState<T, F> CurrentState { get; set; }
	protected virtual T Ctx { get; set; }
	protected virtual F Factory { get; set; }
	protected virtual IState<T, F> CurrentSubState { get; set; }
	protected virtual IState<T, F> CurrentSuperState { get; set; }
	protected bool IsRoot { get => isRoot; set => isRoot = value; }

	public IState(T stateMachine, F factory)
	{
		Ctx = stateMachine;
		Factory = factory;
	}
	public virtual void Enter() { }
	public virtual void Exit() { }
	public virtual void Update() { }
	public virtual void FixedUpdate() { }
	public virtual void CheckSwitchState() { }
	public virtual void InitialSubState() { }

	protected virtual void SwitchState(IState<T, F> newState)
	{
		ExitStates();
		newState.Enter();
		// if (IsRoot)
		// {
		// 	Ctx.CurrentState = (PlayerState)newState;
		// } else {
		// 	CurrentSuperState?.SetSubState(newState);
		// }
	}

	public void EnterStates()
	{
		Enter();
		CurrentSubState?.EnterStates();
	}
	public void UpdateStates()
	{
		Update();
		CurrentSubState?.UpdateStates();
	}
	public void FixedUpdateStates()
	{
		FixedUpdate();
		CurrentSubState?.FixedUpdateStates();
	}
	public void ExitStates()
	{
		Exit();
		CurrentSubState?.ExitStates();
	}

	public void SetSuperState(IState<T, F> newSuperState)
	{
		CurrentSuperState = newSuperState;
	}

	public void SetSubState(IState<T, F> newSubState)
	{
		CurrentSubState = newSubState;
		newSubState.SetSuperState(this);
	}
}
