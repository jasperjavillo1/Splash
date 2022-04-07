public abstract class PlayerMovementBaseState 
{
    protected PlayerMovementStateMachine _ctx;
    protected PlayerStateFactory _factory;
    public PlayerMovementBaseState(PlayerMovementStateMachine context, PlayerStateFactory factory)
    {
        _ctx = context;
        _factory = factory;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
    public abstract void CheckSwitchState();
    public abstract void InitizeSubState();

    protected void UpdateStates() { }
    protected void SwitchState(PlayerMovementBaseState newState)
    {
        //current state's ExitState()
        ExitState();
        //new state's EnterState()
        newState.EnterState();
        //change current state to newState
        _ctx.CurrentState = newState;

    }
    protected void SetSuperState() { }
    protected void SetSubState() { }
}
