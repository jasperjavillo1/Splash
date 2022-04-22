using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerMovementBaseState
{
    private Coroutine cancelJump;
    public PlayerJumpState(PlayerMovementStateMachine context, PlayerStateFactory factory) : base(context, factory)
    {
        IsRootState = true;
        InitizeSubState();
    }
    public override void EnterState()
    {
        Ctx.JumpAvailable = false;
        cancelJump = Ctx.StartCoroutine(HoldJump());
        handleJump();
        Ctx._ChangeAnimationState("Player_jump");
    }
    public override void UpdateState()
    {
        CheckSwitchState();
    }
    public override void ExitState() { }
    public override void CheckSwitchState()
    {
        if(!Ctx.IsJumpPressed)
        {
            Ctx.StopCoroutine(cancelJump);
            stopJump();
        }
        if(Ctx.IsGrounded() && Ctx.JumpAvailable)
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

    private void handleJump()
    {
        Ctx.CurrentMovementY = Ctx.JumpVector.y * Time.deltaTime;
        Ctx.PlayerHealth.DecreaseHealth(50f);
    }

    private void stopJump()
    {
        Vector2 currentVelocity = Ctx.Rigidbody2D.velocity;
        currentVelocity.y = 0;
        Ctx.Rigidbody2D.velocity = currentVelocity;
    }

    private IEnumerator HoldJump()
    {
        yield return new WaitForSeconds(Ctx.MaxJumpTime);
        stopJump();
    }
}