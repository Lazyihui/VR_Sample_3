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

    }

    public static void Tick(GameContext ctx, float dt) {
        PreTick(ctx, dt);



    }

    static void LateTick(GameContext ctx, float dt) {

    }

}