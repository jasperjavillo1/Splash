public class PlayerStateFactory
{
    private PlayerMovementStateMachine _context;
    
    public PlayerStateFactory(PlayerMovementStateMachine currentContext)
    {
        _context = currentContext;
    }

    public PlayerMovementBaseState Idle()
    {
        return new PlayerIdleState(_context, this);
    }
    public PlayerMovementBaseState Walk()
    {
        return new PlayerWalkState(_context, this);
    }
    public PlayerMovementBaseState Run()
    {
        return new PlayerRunState(_context, this);
    }
    public PlayerMovementBaseState Jump()
    {
        return new PlayerJumpState(_context, this); 
    }
    public PlayerMovementBaseState Grounded()
    {
        return new PlayerGroundedState(_context, this);
    }
}
