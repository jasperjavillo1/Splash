using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerMovementBaseState
{
    public PlayerWalkState(PlayerMovementStateMachine context, PlayerStateFactory factory) : base(context, factory) { }
    public override void EnterState()
    {
        Ctx.CurrentMaxSpeed = Ctx.MaxWalkSpeed;
        Ctx.CurrentMovement = Ctx.CurrentWalkMovement;
        Ctx.ResetVelocity();
    }
    public override void UpdateState()
    {
        CheckSwitchState();
    }
    public override void ExitState() { }
    public override void CheckSwitchState()
    {
        if (!Ctx.IsMovementPressed && !Ctx.IsRunPressed)
        {
            SwitchState(Factory.Idle());
        }
        else if (Ctx.IsMovementPressed && Ctx.IsRunPressed)
        {
            SwitchState(Factory.Run());
        }
    }
    public override void InitizeSubState() { }
}
