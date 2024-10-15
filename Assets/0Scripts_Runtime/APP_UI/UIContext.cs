using System;
using System.Collections.Generic;
using UnityEngine;

public class UIContext {

    public Panel_Login panel_Login;

    public Panel_A panel_A;
    public UIEvent uiEvent;

    public UIContext() {
        uiEvent = new UIEvent();
    }
}