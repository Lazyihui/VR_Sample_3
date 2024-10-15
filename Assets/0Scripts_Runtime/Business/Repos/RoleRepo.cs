using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoleRepository
{
    Dictionary<int, RoleEntity> all;

    RoleEntity[] temArray;

    public RoleRepository()
    {
        all = new Dictionary<int, RoleEntity>();
        temArray = new RoleEntity[1000];
    }

    public void Add(RoleEntity entity)
    {
        all.Add(entity.id, entity);
    }

    public void Remove(RoleEntity entity)
    {
        all.Remove(entity.id);
    }

    public bool TryGet(int id, out RoleEntity entity)
    {
        return all.TryGetValue(id, out entity);
    }

    public int TakeAll(out RoleEntity[] entity)
    {
        all.Values.CopyTo(temArray, 0);
        entity = temArray;
        return all.Count;
    }
}