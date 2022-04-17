public abstract class PlayerMovementBaseState 
{
    private bool _isRootState = false;
    private PlayerMovementStateMachine _ctx;
    private PlayerStateFactory _factory;
    private PlayerMovementBaseState _currentSuperState;
    private PlayerMovementBaseState _currentSubState;

    protected bool IsRootState { get { return _isRootState; } set { _isRootState = value; } }
    protected PlayerMovementStateMachine Ctx { get { return _ctx; } }
    protected PlayerStateFactory Factory { get { return _factory; } set { _factory = value; } }
    protected PlayerMovementBaseState CurrentSuperState { get { return _currentSuperState; } }

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

    public void UpdateStates()
    {
        UpdateState();
        if(_currentSubState != null)
        {
            _currentSubState.UpdateStates();
        }
    }
    protected void SwitchState(PlayerMovementBaseState newState)
    {
        //current state's ExitState()
        ExitState();
        //new state's EnterState()
        newState.EnterState();
        //change current state to newState
        if (_isRootState)
        {
            _ctx.CurrentState = newState;
        }
        else if(_currentSuperState != null)
        {
            _currentSuperState.SetSubState(newState);
        }

    }
    protected void SetSuperState(PlayerMovementBaseState newSuperState)
    {
        _currentSuperState = newSuperState;
    }
    protected void SetSubState(PlayerMovementBaseState newSubState)
    {
        _currentSubState = newSubState;
        newSubState.SetSuperState(this);
    }
}
