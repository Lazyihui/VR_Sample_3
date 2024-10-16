using System;
using UnityEngine;

public class PlaneEntity : MonoBehaviour {
    public int id;
    public float moveSpeed;
    public void Ctor() {
        moveSpeed = 3.5f;
    }
    public void SetPos(Vector3 pos) {
        this.transform.position = pos;
    }

}