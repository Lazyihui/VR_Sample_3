using System;
using UnityEngine;



public static class InputCore {


    public static void Tick(GameContext ctx) {


        // 得到手的左手输入移动
        {
            Vector2 moveAxis = ctx.inputContext.inputActions.XRILeftHandLocomotion.Move.ReadValue<Vector2>();
            ctx.inputContext.leftHand.moveAxis = moveAxis;

        }
        // 得到右手的输入移动
        {
            Vector2 moveAxis = ctx.inputContext.inputActions.XRIRightHandLocomotion.Move.ReadValue<Vector2>();
            ctx.inputContext.rightHand.moveAxis = moveAxis;
        }
        {

        }
        // 按下A键
        {
            float a = ctx.inputContext.inputActions.XRILeftHandInteraction.PressA.ReadValue<float>();
            if (a > 0.5f) {
                ctx.inputContext.leftHand.isPressA = true;
            } else {
                ctx.inputContext.leftHand.isPressA = false;

            }

            float rightA = ctx.inputContext.inputActions.XRIRightHandInteraction.PressA.ReadValue<float>();
            if (rightA > 0.5f) {
                ctx.inputContext.rightHand.isPressA = true;
            } else {
                ctx.inputContext.rightHand.isPressA = false;
            }
        }



    }

}