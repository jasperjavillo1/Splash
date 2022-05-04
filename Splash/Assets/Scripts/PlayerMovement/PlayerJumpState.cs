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
        Ctx.StartCoroutine(DelayJumpAvilable());
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
            SwitchState(Factory.Falling());
        }
        if(Ctx.IsGrounded() && Ctx.JumpAvailable)
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

    private void handleJump()
    {
        Ctx.Rigidbody2D.AddForce(Ctx.JumpVector, ForceMode2D.Impulse);
        if (!Ctx.PlayerHealth.IsInBossFight)
        {
            //Ctx.PlayerHealth.DecreaseHealth(50f);
        }
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
    private IEnumerator DelayJumpAvilable()
    {
        yield return new WaitForSeconds(0.1f);
        Ctx.JumpAvailable = true;
    }
}