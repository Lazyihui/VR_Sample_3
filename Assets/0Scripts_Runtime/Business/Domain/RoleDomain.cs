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


    public static void Stand_Follow(RoleEntity role, Vector3 follow_Target, float follow_distance, Vector3 face, float dt) {

        Vector3 newPos = follow_Target + -face * follow_distance;

        role.transform.position = newPos;


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
    public static void RoleToPlanePos(GameContext ctx, RoleEntity role, PlaneEntity plane) {

        Vector3 pos = role.transform.position;
        Vector3 planePos = plane.transform.position;

        float distance = Vector3.Distance(pos, planePos);


        if (distance < 4) {
            ctx.gameEntity.isDistanceOK = true;
        }

    }
    public static void Clear(GameContext ctx, RoleEntity entity) {

        ctx.roleRepository.Remove(entity);
        GameObject.Destroy(entity.gameObject);

    }

}