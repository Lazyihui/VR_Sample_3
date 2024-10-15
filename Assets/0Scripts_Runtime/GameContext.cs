using System;
using UnityEngine;



public class GameContext {
    public GameEntity gameEntity;

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

    public RoleEntity Role_GetOwner() {
        bool has = roleRepository.TryGet(gameEntity.ownerID, out RoleEntity entity);
        if (!has) {
            Debug.LogError("GameContext.Role_GetOwner: ownerID not found");
            return null;
        }
        return entity;
    }


}