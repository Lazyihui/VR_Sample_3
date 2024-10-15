using System;
using UnityEngine;


public class InputEntity {
    public int id;

    public Vector2 moveAxis;

    public bool isPressA;

    public InputEntity() {
        moveAxis = Vector2.zero;
        isPressA = false;
    }


}