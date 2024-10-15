using System;
using UnityEngine;


public static class Login_Business {


    public static void Enter(GameContext ctx) {
        RoleDomain.Spawan(ctx);

    }


    static void PreTick(GameContext ctx, float dt) {

        // 有点小问题先不管
        ctx.gameEntity.LoginTime += dt;
        if (ctx.gameEntity.LoginTime > 3) {
            ctx.gameEntity.isLoginOpen = true;
        }

        if (ctx.gameEntity.isLoginOpen) {
            AppUI.Panel_Login_Open(ctx);
            ctx.gameEntity.isLoginOpen = false;
        }
        // 



    }

    public static void Tick(GameContext ctx, float dt) {
        PreTick(ctx, dt);

        
    }

    static void LateTick(GameContext ctx, float dt) {

    }

}