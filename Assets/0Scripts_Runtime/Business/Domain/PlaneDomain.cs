using System;
using UnityEngine;



public static class PlaneDomain {
    public static PlaneEntity Spawan(GameContext ctx) {


        bool has = ctx.assetsContext.entities.TryGetValue("Entity_Plane", out GameObject prefab);
        if (!has) {
            Debug.LogError("Entity_Plane not found");
            return null;
        }

        GameObject go = GameObject.Instantiate(prefab);
        PlaneEntity entity = go.GetComponent<PlaneEntity>();


        entity.Ctor();
        

        ctx.planeRepository.Add(entity);
        return entity;

    }



    public static void Move(PlaneEntity entity, Vector2 moveAxis, float dt) {


        Vector3 moveDir = new Vector3(moveAxis.x, 0, moveAxis.y);
        moveDir.Normalize();

        // if (moveDir != Vector3.zero) {
        //     entity.transform.forward = moveDir;
        // }
        Debug.Log("moveDir:" + moveDir);

        moveDir = moveDir * entity.moveSpeed * dt;
        entity.transform.position += moveDir;

        Debug.Log("entity.transform.position:" + entity.transform.position);

    }



    public static void Clear(GameContext ctx, PlaneEntity entity) {

        ctx.planeRepository.Remove(entity);
        GameObject.Destroy(entity.gameObject);

    }

}