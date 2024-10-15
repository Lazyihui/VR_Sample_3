using System;
using UnityEngine;



public class InputContext {
    public InputEntity head;


    public InputEntity leftHand;

    public InputEntity rightHand;

    public XRIDefaultInputActions inputActions;

    public InputContext() {
        head = new InputEntity();
        leftHand = new InputEntity();
        rightHand = new InputEntity();

        inputActions = new XRIDefaultInputActions();
        inputActions.Enable();
    }


}