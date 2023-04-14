using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiGameOverScreen : MonoBehaviour
{
    [SerializeField] private Button btn_Reload;

    private void Awake() {

        btn_Reload.onClick.AddListener(OnclickOnReloadBtnClick);
    }

    private void OnclickOnReloadBtnClick() {
        SceneManager.LoadScene(0);
    }
}
