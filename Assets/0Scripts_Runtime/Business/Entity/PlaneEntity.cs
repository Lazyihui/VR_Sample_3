using System;
using UnityEngine;

public class PlaneEntity : MonoBehaviour {
    public int id;
    public float moveSpeed;
    public void Ctor() {
        moveSpeed = 5.5f;
    }
    public void SetPos(Vector3 pos) {
        this.transform.position = pos;
    }

    void OntriggerEnter(Collider other) {

        if (other.CompareTag("Patrol")) {

            Destroy(other.gameObject);

            Debug.Log("OntriggerEnter");

        } else {
            Debug.Log("OntriggerEnter");
        }

    }

    void OntriggerStay(Collider other) {

        

    }

}