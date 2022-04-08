using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerMovementBaseState
{
    public PlayerJumpState(PlayerMovementStateMachine context, PlayerStateFactory factory) : base(context, factory) { }
    public override void EnterState()
    {
        _handleJump();    
    }
    public override void UpdateState()
    {
        CheckSwitchState();
    }
    public override void ExitState() { }
    public override void CheckSwitchState()
    {
        if(_ctx.IsGrounded())
        {
            SwitchState(_factory.Grounded());
        }
    }
    public override void InitizeSubState() { }

    private void _handleJump()
    {
        _ctx.Rigidbody2D.velocity = _ctx.JumpVector;
        _ctx.IsJumping = true;
    }
}