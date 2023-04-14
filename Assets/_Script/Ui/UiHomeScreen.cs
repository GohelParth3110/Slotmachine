using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiHomeScreen : MonoBehaviour
{
    [SerializeField] private Button btn_Start;

    private void Awake() {

        btn_Start.onClick.AddListener(OnclickOnStartBtnClick);
    }

   

    private void OnclickOnStartBtnClick() {
        this.gameObject.SetActive(false);
        UiManager.instance.GetLevelScreen.gameObject.SetActive(true);
    }
}
