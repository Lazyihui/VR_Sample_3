using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.ResourceManagement.AsyncOperations;


public class AssetsContext {
    public Dictionary<string, GameObject> entities;

    public AsyncOperationHandle entityPtr;


    public AssetsContext() {
        entities = new Dictionary<string, GameObject>();
    }
}