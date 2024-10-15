using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleEntity : MonoBehaviour
{
    
    [SerializeField] public GameObject head;

    [SerializeField] GameObject leftController;

    [SerializeField] GameObject rightController;

    [SerializeField] public Vector3 planePos;


    public float moveSpeed;

    public int id;

    public void Ctor()
    {
        moveSpeed = 5.5f;
    }

    public void SetPos()
    {

    }
}
