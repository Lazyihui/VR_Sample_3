using System;
using UnityEngine;


public static class Game_Business {


    public static void Enter(GameContext ctx) {
        ctx.gameEntity.gameState = GameState.Game;

        ctx.planeRepository.TryGet(ctx.gameEntity.planeID, out PlaneEntity plane);

        plane.SetPos(new Vector3(-42.1f, 6.4f, -60.83f));

        ctx.roleRepository.TryGet(ctx.gameEntity.ownerID, out RoleEntity role);

        Vector3 pos = new Vector3(plane.transform.position.x, plane.transform.position.y, plane.transform.position.z - 0.5f);

        role.SetPos(pos);

        role.HideHead();

    }


    static void PreTick(GameContext ctx, float dt) {
        InputCore.Tick(ctx);
    }

    public static void Tick(GameContext ctx, float dt) {
        PreTick(ctx, dt);
        ctx.roleRepository.TryGet(ctx.gameEntity.ownerID, out RoleEntity role);

        ctx.planeRepository.TryGet(ctx.gameEntity.planeID, out PlaneEntity plane);

        Vector2 moveAxis = ctx.inputContext.leftHand.moveAxis;
        Vector3 right = role.transform.right;
        Vector3 forward = role.transform.forward;

        right = right * moveAxis.x;
        forward = forward * moveAxis.y;

        Vector2 moveDir = right + forward;
        moveAxis.Normalize();

        PlaneDomain.MoveHori(plane, ctx.inputContext.leftHand.moveAxis, dt);
        PlaneDomain.MoveUpDown(plane, ctx.inputContext.rightHand.moveAxis.y, dt);

        float rotateSpeed = 30f;
        float x = ctx.inputContext.rightHand.moveAxis.x * rotateSpeed * dt;

        if (x != 0) {
            // 相机旋转 飞机的位置不变但是要旋转
            RoleDomain.Round(role, plane.transform.position, 0.5f, new Vector3(0, x, 0));
            PlaneDomain.Face(plane, role.transform.forward);
        } else {
            RoleDomain.Stand_Follow(role, plane.transform.position, 0.5f, plane.transform.forward, dt);

        }

        LateTick(ctx, dt);


    }

    static void LateTick(GameContext ctx, float dt) {
        if (ctx.inputContext.rightHand.isPressA) {

            AppUI.Panel_Patrol_Open(ctx, "巡逻完成");
            ctx.gameEntity.isPatrolOpen = true;
        }


        if (ctx.gameEntity.isPatrolOpen) {
            ctx.gameEntity.PatrolTime += dt;

            if (ctx.gameEntity.PatrolTime > 3) {
                AppUI.Panel_Patrol_Close(ctx);
                ctx.gameEntity.PatrolTime = 0;
                ctx.gameEntity.isPatrolOpen = false;
            }
        }
    }

}