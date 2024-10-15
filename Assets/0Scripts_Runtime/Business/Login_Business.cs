using System;
using UnityEngine;


public static class Login_Business {


    public static void Enter(GameContext ctx) {
        RoleDomain.Spawan(ctx);

    }


    static void PreTick(GameContext ctx, float dt) {


        if (ctx.gameEntity.isLoginOpen == false) {

            ctx.gameEntity.LoginTime += dt;
            if (ctx.gameEntity.LoginTime > 3) {
                ctx.gameEntity.isLoginOpen = true;
                AppUI.Panel_Login_Open(ctx);
            }
        }

    }

    public static void Tick(GameContext ctx, float dt) {
        PreTick(ctx, dt);

        InputCore.Tick(ctx);

        RoleEntity role = ctx.Role_GetOwner();

        // Vector2 moveAxis = ctx.inputContext.leftHand.moveAxis;
        // Vector3 right = role.transform.right;
        // Vector3 forward = role.transform.forward;
        // right = right * moveAxis.x;
        // forward = forward * moveAxis.y;
        // Vector3 moveDir = right + forward;
        // moveDir.Normalize();


        // moveAxis = new Vector2(moveDir.x, moveDir.z);

        Vector2 moveAxis = ctx.inputContext.leftHand.moveAxis;
        Vector3 right = role.transform.right;
        Vector3 forward = role.transform.forward;
        right = right * moveAxis.x;
        forward = forward * moveAxis.y;
        Vector3 moveDir = right + forward;
        moveDir.Normalize();

        moveAxis = new Vector2(moveDir.x, moveDir.z);


        RoleDomain.Move(role, moveAxis, dt);
        RoleDomain.RoleToPlanePos(role);

    }

    static void LateTick(GameContext ctx, float dt) {

    }

}