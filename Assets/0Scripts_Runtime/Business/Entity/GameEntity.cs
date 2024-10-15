using System;
using UnityEngine;


public class GameEntity {
    public int ownerID;

    public int planeID;

    public float LoginTime;

    public bool isLoginOpen;

    public GameState gameState;

    public bool isPressAOpen;

    public bool isDistanceOK;


    public GameEntity() {
        ownerID = 0;
        planeID = 0;
        LoginTime = 0;
        isLoginOpen = false;
        isPressAOpen = false;
        isDistanceOK = false;
        gameState = GameState.Login;

    }


}
