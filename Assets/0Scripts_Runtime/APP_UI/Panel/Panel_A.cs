using System;
using UnityEngine;



public class Panel_A : MonoBehaviour {


    public void Ctor() {

    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void TearDown() {
        Destroy(gameObject);
    }
}