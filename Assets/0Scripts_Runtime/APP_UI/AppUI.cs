using System;
using System.Collections.Generic;
using UnityEngine;


public static class AppUI {
    public static void Panel_Login_Open(GameContext ctx) {
        Panel_Login panel = ctx.uiContext.panel_Login;

        if (panel == null) {
            bool has = ctx.assetsContext.entities.TryGetValue("Panel_Login", out GameObject prefab);

            if (!has) {
                Debug.LogError("Panel_Login_Open: prefab not found");
                return;
            }

            GameObject go = GameObject.Instantiate(prefab);
            panel = go.GetComponent<Panel_Login>();

            panel.Ctor();

            panel.onStartBtnClick = () => {
                ctx.uiContext.uiEvent.OnStartButtonClickedEvent();
            };

        }

        panel.Show();
        ctx.uiContext.panel_Login = panel;

    }

    public static void Panel_Login_Close(GameContext ctx) {
        Panel_Login panel = ctx.uiContext.panel_Login;
        if (panel == null) {
            return;
        }
        panel.TearDown();

    }

}