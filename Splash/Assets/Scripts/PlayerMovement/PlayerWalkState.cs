using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerMovementBaseState
{
    public PlayerWalkState(PlayerMovementStateMachine context, PlayerStateFactory factory) : base(context, factory) { }
    public override void EnterState() { }
    public override void UpdateState()
    {
        CheckSwitchState();
    }
    public override void ExitState() { }
    public override void CheckSwitchState() { }
    public override void InitizeSubState() { }
}
