using System;
using UnityEngine;


public class GameEntity {
    public int ownerID;

    public float LoginTime;

    public bool isLoginOpen;

    public GameState gameState;

    
    public GameEntity() {
        ownerID = 0;
        LoginTime = 0;
        isLoginOpen = false;

        gameState = GameState.Login;

    }


}
