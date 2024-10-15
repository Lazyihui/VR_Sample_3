using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Panel_Login : MonoBehaviour {

    [SerializeField] TextMeshProUGUI txt;


    [SerializeField] Button startBtn;

    public Action onStartBtnClick;

    public char[] textContent;

    public int index;
    public float time;
    public void Ctor() {


        startBtn.onClick.AddListener(() => {
            if (onStartBtnClick != null) {
                onStartBtnClick.Invoke();
            }
        });

        textContent = txt.text.ToCharArray();
        txt.text = "";
        index = 0;
    }

    public void Update() {
        float dt = Time.deltaTime;
        time += dt;
        if (time % 3 == 0) {
            if (index < textContent.Length) {
                txt.text += textContent[index];
                index++;
            } else {
                startBtn.gameObject.SetActive(true);
            }
        }

    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void TearDown(){
        Destroy(gameObject);
    }
}