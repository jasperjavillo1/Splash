public abstract class PlayerMovementBaseState 
{
    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
    public abstract void CheckSwitchState();
    public abstract void InitizeSubState();

    protected void UpdateStates() { }
    protected void SwitchState() { }
    protected void SetSuperState() { }
    protected void SetSubState() { }
}
