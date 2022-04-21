using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerMovementBaseState
{
    private Coroutine _stopJump;
    public PlayerJumpState(PlayerMovementStateMachine context, PlayerStateFactory factory) : base(context, factory)
    {
        IsRootState = true;
        InitizeSubState();
    }
    public override void EnterState()
    {
        Debug.Log("Enter Jump");
        _handleJump();
        //Ctx._ChangeAnimationState("Player_jump");
        _stopJump = Ctx.StartCoroutine(_reachJumpPeak());
    }
    public override void UpdateState()
    {
        CheckSwitchState();
    }
    public override void ExitState() { Debug.Log("Exit Jump"); }
    public override void CheckSwitchState()
    {
        if(Ctx.IsGrounded())
        {
            SwitchState(Factory.Grounded());
        }
        if(!Ctx.IsJumpPressed || Ctx.HitCeiling())
        {
            Ctx.StopCoroutine(_stopJump);
            SwitchState(Factory.Falling());
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

    private void _handleJump()
    {
        Ctx.CurrentMovementY = Ctx.JumpVector.y * Time.deltaTime;
        Ctx.PlayerHealth.DecreaseHealth(50f);
    }

    private IEnumerator _reachJumpPeak()
    {
        yield return new WaitForSecondsRealtime(0.25f);
        SwitchState(Factory.Falling());
    }
}