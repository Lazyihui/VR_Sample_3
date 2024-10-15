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
    }

    void Update() {

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
