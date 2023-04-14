using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class UiPayRentScreen : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI txt_Message;
    [SerializeField] private Button btn_Pay;

    private void Awake() {
        btn_Pay.onClick.AddListener(OnClickOnBtn_PayClick); 
    }
    private void OnEnable() {
        Message();
    }
    private void Message() {
        txt_Message.text = "pay rent of  " + LevelManager.instance.CurrentLevel.RentValue;
    }
    private void OnClickOnBtn_PayClick() {

        GameManager.instance.UpdateScore(-LevelManager.instance.CurrentLevel.RentValue);
        LevelManager.instance.IncreasingLevel();
        UiManager.instance.GetLevelScreen.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

    
}
