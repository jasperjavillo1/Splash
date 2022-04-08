using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerMovementBaseState
{
    public PlayerGroundedState(PlayerMovementStateMachine context, PlayerStateFactory factory) : base(context, factory) { }
    public override void EnterState() { }
    public override void UpdateState()
    {
        CheckSwitchState();
    }
    public override void ExitState() { }
    public override void CheckSwitchState()
    {
        if(_ctx.IsJumpPressed)
        {
            SwitchState(_factory.Jump());
        }
    }
    public override void InitizeSubState() { }
}
