using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlaneRepository
{
    Dictionary<int, PlaneEntity> all;

    PlaneEntity[] temArray;

    public PlaneRepository()
    {
        all = new Dictionary<int, PlaneEntity>();
        temArray = new PlaneEntity[1000];
    }

    public void Add(PlaneEntity entity)
    {
        all.Add(entity.id, entity);
    }

    public void Remove(PlaneEntity entity)
    {
        all.Remove(entity.id);
    }

    public bool TryGet(int id, out PlaneEntity entity)
    {
        return all.TryGetValue(id, out entity);
    }

    public int TakeAll(out PlaneEntity[] entity)
    {
        all.Values.CopyTo(temArray, 0);
        entity = temArray;
        return all.Count;
    }
}