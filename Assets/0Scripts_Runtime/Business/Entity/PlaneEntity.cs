using System;
using UnityEngine;

public class PlaneEntity : MonoBehaviour {
    public int id;
    public float moveSpeed;
    public void Ctor() {
    }
    public void SetPos(Vector3 pos) {
        this.transform.position = pos;
    }

}