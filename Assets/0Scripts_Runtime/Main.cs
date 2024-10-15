using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    GameContext ctx;

    bool isTearDown = false;
    void Awake() {
        ctx = new GameContext();

        ctx.Inject();

        AssetsCore.Load(ctx.assetsContext);

        Login_Business.Enter(ctx);

        Binding();
    }


    void Binding() {
        var uiContext = ctx.uiContext;


        uiContext.uiEvent.OnStartButtonClicked = () => {

            AppUI.Panel_Login_Close(ctx);
            // ctx.gameEntity.gameState = GameState.Game;
            Game_Business.Enter(ctx);

        };


    }

    void Update() {
        float dt = Time.deltaTime;

        if (ctx.gameEntity.gameState == GameState.Login) {
            Login_Business.Tick(ctx, dt);

        } else if (ctx.gameEntity.gameState == GameState.Game) {
            Game_Business.Tick(ctx, dt);

        }
    }


    void OnDestroy() {

    }

    void OnApplicationQuit() {

    }


    void TearDown() {
        if (isTearDown) {
            return;
        }

        isTearDown = true;

        AssetsCore.UnLoad(ctx.assetsContext);

    }
}
