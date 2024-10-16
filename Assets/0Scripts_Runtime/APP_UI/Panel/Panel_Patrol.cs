using System;
using UnityEngine;
using TMPro;


public class Panel_Patrol : MonoBehaviour {

    [SerializeField] TextMeshProUGUI txt;

    public void Ctor() {
    }


    public void SetText(String txt) {
        this.txt.text = txt;
    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void TearDown() {
        Destroy(gameObject);
    }
}