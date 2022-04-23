using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerMovementBaseState
{


    public PlayerGroundedState(PlayerMovementStateMachine context, PlayerStateFactory factory) : base(context, factory)
    {
        IsRootState = true;
        InitizeSubState();

    }
    public override void EnterState() { }
    public override void UpdateState()
    {
        CheckSwitchState();
    }
    public override void ExitState() { }
    public override void CheckSwitchState()
    {
        if(Ctx.IsJumpPressed && Ctx.JumpAvailable)
        {
            SwitchState(Factory.Jump());
        }
        if(!Ctx.IsGrounded())
        {
            SwitchState(Factory.Falling());
        }
    }
    public override void InitizeSubState()
    {
        if(!Ctx.IsMovementPressed && !Ctx.IsRunPressed)
        {
            SetSubState(Factory.Idle());
        }
        else if(Ctx.IsMovementPressed && !Ctx.IsRunPressed)
        {
            SetSubState(Factory.Walk());
        }
        else if(Ctx.IsMovementPressed && Ctx.IsRunPressed)
        {
            SetSubState(Factory.Run());
        }
    }
}
