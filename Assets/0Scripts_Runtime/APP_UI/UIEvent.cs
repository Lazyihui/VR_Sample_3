using System;
using System.Collections.Generic;
using UnityEngine;


public class UIEvent {

    public Action OnStartButtonClicked;

    public void OnStartButtonClickedEvent() {
        if (OnStartButtonClicked != null) {
            OnStartButtonClicked();
        }
    }
}