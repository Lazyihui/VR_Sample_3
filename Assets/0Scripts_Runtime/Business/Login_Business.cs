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

                ctx.roleRepository.TryGet(ctx.gameEntity.ownerID, out RoleEntity role);
                role.roleState = RoleState.Move;
            }
        }

        if (ctx.gameEntity.isPressAOpen == false) {

            if (ctx.gameEntity.isDistanceOK) {
                ctx.gameEntity.isPressAOpen = true;
                AppUI.Panel_A_Open(ctx);
            }

        }



    }

    public static void Tick(GameContext ctx, float dt) {
        PreTick(ctx, dt);

        InputCore.Tick(ctx);

        ctx.roleRepository.TryGet(ctx.gameEntity.ownerID, out RoleEntity role);

        Vector2 moveAxis = ctx.inputContext.leftHand.moveAxis;
        Vector3 right = role.transform.right;
        Vector3 forward = role.transform.forward;
        right = right * moveAxis.x;
        forward = forward * moveAxis.y;
        Vector3 moveDir = right + forward;
        moveDir.Normalize();

        moveAxis = new Vector2(moveDir.x, moveDir.z);

        if (role.roleState == RoleState.Move) {
            RoleDomain.Move(role, moveAxis, dt);
            RoleDomain.RoleToPlanePos(ctx, role, ctx.Plane_GetOwner());
        }


        if (ctx.inputContext.leftHand.isPressA) {

            AppUI.Panel_A_Close(ctx);
            Game_Business.Enter(ctx);
            // ctx.gameEntity.gameState = GameState.Game;
            // RoleDomain.Clear(ctx, role);

        }
        



    }

    static void LateTick(GameContext ctx, float dt) {

    }

}