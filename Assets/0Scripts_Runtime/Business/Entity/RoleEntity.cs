using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleEntity : MonoBehaviour {

    [SerializeField] public GameObject head;

    [SerializeField] GameObject leftController;

    [SerializeField] GameObject rightController;

    public RoleState roleState;

    public float moveSpeed;

    public int id;

    public void Ctor() {
        moveSpeed = 5.5f;
        roleState = RoleState.Idle;

    }

    public void HideHead() {
        leftController.SetActive(false);
        rightController.SetActive(false);
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
    }


    public void SetPos(Vector3 pos) {
        this.transform.position = pos;
    }
}
