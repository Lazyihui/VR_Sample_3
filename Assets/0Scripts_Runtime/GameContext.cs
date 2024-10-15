using System;
using UnityEngine;



public class GameContext {

    // ctx
    public AssetsContext assetsContext;

    // rops
    public RoleRepository roleRepository;
    public GameContext() {
        // ctx
        assetsContext = new AssetsContext();

        // repo
        roleRepository = new RoleRepository();
    }

    public void Inject() {

    }
}