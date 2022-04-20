using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallingState : PlayerMovementBaseState
{
    public PlayerFallingState(PlayerMovementStateMachine context, PlayerStateFactory factory) : base(context, factory)
    {
        IsRootState = true;
        InitizeSubState();
    }

    public override void EnterState()
    {
        Ctx.CurrentMovementY = Ctx.Gravity.y * Time.deltaTime;
    }
    public override void UpdateState()
    {
        CheckSwitchState();
    }
    public override void ExitState() { }
    public override void CheckSwitchState()
    {
        if (Ctx.IsGrounded())
        {
            SwitchState(Factory.Grounded());
        }
    }
    public override void InitizeSubState()
    {
        if (!Ctx.IsMovementPressed && !Ctx.IsRunPressed)
        {
            SetSubState(Factory.Idle());
        }
        else if (Ctx.IsMovementPressed && !Ctx.IsRunPressed)
        {
            SetSubState(Factory.Walk());
        }
        else if (Ctx.IsMovementPressed && Ctx.IsRunPressed)
        {
            SetSubState(Factory.Run());
        }
    }
}
