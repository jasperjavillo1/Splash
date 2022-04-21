using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerMovementBaseState
{
    public PlayerIdleState(PlayerMovementStateMachine context, PlayerStateFactory factory) : base(context, factory) { }
    public override void EnterState()
    {
        Ctx.CurrentMaxSpeed = 0;
        Ctx.CurrentMovement = new Vector2(0, 0);
        Ctx.ResetVelocity();
    }
    public override void UpdateState()
    {
        CheckSwitchState();
    }
    public override void ExitState() { }
    public override void CheckSwitchState()
    {
        if(Ctx.IsMovementPressed && !Ctx.IsRunPressed)
        {
            SwitchState(Factory.Walk());
        }
        else if(Ctx.IsMovementPressed && Ctx.IsRunPressed)
        {
            SwitchState(Factory.Run());
        }
    }
    public override void InitizeSubState(){ }
}