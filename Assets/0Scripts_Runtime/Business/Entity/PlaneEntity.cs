using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlaneEntity : MonoBehaviour {
    public int id;
    public float moveSpeed;
    [SerializeField] GameObject hand;
    [SerializeField] XRRayInteractor rayInteractor;
    public Vector3 endPos;

    public void Ctor() {
        moveSpeed = 5.5f;
        hand.gameObject.SetActive(false);
    }
    public void SetPos(Vector3 pos) {
        this.transform.position = pos;
    }

    void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Patrol")) {

            Destroy(other.gameObject);
            Debug.Log("OntriggerEnter");

        } else {
            Debug.Log("OntriggerEnter");
        }

    }

    public void Update() {
        endPos = rayInteractor.rayEndPoint;

        bool has = rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit, out int raycastEndpointIndex);
        if (has) {
            Debug.Log(rayInteractor.rayEndPoint);
            Debug.Log("hit:" + hit.point + " " + hit.collider.gameObject.name + hit.transform.name);
        }

    }

    public void SetHeadActive(bool active) {
        hand.gameObject.SetActive(active);
    }

    void OnTriggerStay(Collider other) {



    }

}