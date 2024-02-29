using System.Collections.Generic;

public abstract class Factory<StatesEnum, S, SM> {
	public abstract Dictionary<StatesEnum, S> States { get; }
	public Factory(SM sm) {}
}
