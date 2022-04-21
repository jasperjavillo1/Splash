using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerMovementBaseState
{
    public PlayerRunState(PlayerMovementStateMachine context, PlayerStateFactory factory) : base(context, factory) { }
    public override void EnterState()
    {
        Ctx.CurrentMaxSpeed = 6;
        Ctx.CurrentMovement = Ctx.CurrentRunMovement;
        Ctx.ResetVelocity();
    }
    public override void UpdateState()
    {
        CheckSwitchState();
    }
    public override void ExitState() { }
    public override void CheckSwitchState()
    {
        if (Ctx.IsMovementPressed && !Ctx.IsRunPressed)
        {
            SwitchState(Factory.Walk());
        }
        else if (!Ctx.IsMovementPressed)
        {
            SwitchState(Factory.Idle());
        }
    }
    public override void InitizeSubState() { }
}
