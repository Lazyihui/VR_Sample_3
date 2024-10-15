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

    public static void Move(RoleEntity entity, Vector2 moveAxis, float dt) {


        Vector3 moveDir = new Vector3(moveAxis.x, 0, moveAxis.y);
        moveDir.Normalize();

        // if (moveDir != Vector3.zero) {
        //     entity.transform.forward = moveDir;
        // }

        moveDir = moveDir * entity.moveSpeed * dt;
        entity.transform.position += moveDir;

    }

    public static void RoleToPlanePos(RoleEntity role) {

        Vector3 pos = role.transform.position;
        Vector3 planePos = role.planePos;

        float distance = Vector3.Distance(pos, planePos);


        if (distance < 70) {

        }

    }

}