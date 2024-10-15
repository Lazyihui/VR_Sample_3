using System;
using UnityEngine;


public static class Login_Business {


    public static void Enter(GameContext ctx) {
        RoleEntity role = RoleDomain.Spawan(ctx);
        role.id = ctx.gameEntity.ownerID;

        PlaneEntity plane = PlaneDomain.Spawan(ctx);
        plane.id = ctx.gameEntity.ownerID;

    }


    static void PreTick(GameContext ctx, float dt) {


        if (ctx.gameEntity.isLoginOpen == false) {

            ctx.gameEntity.LoginTime += dt;
            if (ctx.gameEntity.LoginTime > 3) {
                ctx.gameEntity.isLoginOpen = true;
                AppUI.Panel_Login_Open(ctx);
            }
        }

        if (ctx.gameEntity.isDistanceOK) {
            if (ctx.gameEntity.isPressAOpen == false) {
                ctx.gameEntity.isPressAOpen = true;
                AppUI.Panel_A_Open(ctx);
            }
        }

        if (ctx.inputContext.leftHand.isPressA) {

            AppUI.Panel_A_Close(ctx);
            ctx.gameEntity.gameState = GameState.Game;
            RoleDomain.Clear(ctx, ctx.Role_GetOwner());


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
        RoleDomain.RoleToPlanePos(ctx, role, ctx.Plane_GetOwner());

    }

    static void LateTick(GameContext ctx, float dt) {

    }

}