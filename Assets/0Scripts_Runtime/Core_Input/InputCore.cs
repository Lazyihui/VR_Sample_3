using System;
using UnityEngine;



public static class InputCore {


    public static void Tick(GameContext ctx) {


        // 得到手的输入移动
        {
            Vector2 moveAxis = ctx.inputContext.inputActions.XRILeftHandLocomotion.Move.ReadValue<Vector2>();
            ctx.inputContext.leftHand.moveAxis = moveAxis;
            Debug.Log("InputCore.Tick: leftHand moveAxis=" + moveAxis);

        }

    }

}