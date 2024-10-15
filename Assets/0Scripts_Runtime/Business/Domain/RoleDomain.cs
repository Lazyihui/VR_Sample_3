using System;
using UnityEngine;



public static class RoleDomain {
    public static RoleEntity Spawan(GameContext ctx) {


        bool has = ctx.assetsContext.entities.TryGetValue("Entity_Role", out GameObject prefab);
        if (!has) {
            Debug.LogError("Entity_Role not found");
            return null;
        }

        GameObject go = GameObject.Instantiate(prefab);
        RoleEntity entity = go.GetComponent<RoleEntity>();


        entity.Ctor();


        ctx.roleRepository.Add(entity);
        return entity;

    }
}