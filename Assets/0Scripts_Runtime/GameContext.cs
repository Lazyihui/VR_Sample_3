using System;
using UnityEngine;



public class GameContext {
    public GameEntity gameEntity;

    // ctx
    public AssetsContext assetsContext;

    public UIContext uiContext;

    public InputContext inputContext;

    // rops
    public RoleRepository roleRepository;

    public PlaneRepository planeRepository;
    public GameContext() {
        gameEntity = new GameEntity();

        // ctx
        assetsContext = new AssetsContext();
        uiContext = new UIContext();
        inputContext = new InputContext();
        // repo
        roleRepository = new RoleRepository();
        planeRepository = new PlaneRepository();
    }

    public void Inject() {

    }

    public RoleEntity Role_GetOwner() {
        bool has = roleRepository.TryGet(gameEntity.ownerID, out RoleEntity entity);
        if (!has) {
            Debug.LogError("GameContext.Role_GetOwner: ownerID not found");
            return null;
        }
        return entity;
    }

    public PlaneEntity Plane_GetOwner() {
        bool has = planeRepository.TryGet(gameEntity.ownerID, out PlaneEntity entity);
        if (!has) {
            Debug.LogError("GameContext.Plane_GetOwner: ownerID not found");
            return null;
        }
        return entity;
    }


}