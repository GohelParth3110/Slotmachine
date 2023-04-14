using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class UILevelScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txt_Level;
    [SerializeField] private TextMeshProUGUI txt_Mesasage;
    [SerializeField] private Button btn_ReadMesseage;
   
    private void Awake() {

        btn_ReadMesseage.onClick.AddListener(OnclickOnReadBtnClick);
    }

    private void OnEnable() {
        
        txt_Level.text = "Level " + LevelManager.instance.CurrentLevelNo;
        txt_Mesasage.text = " You have " + LevelManager.instance.CurrentLevel.SpinValue + " spin and after using " + LevelManager.instance.CurrentLevel.SpinValue
                                + " spin you will pay rent " + LevelManager.instance.CurrentLevel.RentValue + " $";
    }

    private void OnclickOnReadBtnClick() {

        if (LevelManager.instance.CurrentLevelNo == 1) {
            this.gameObject.SetActive(false);
            UiManager.instance.GetUiGamePlayScreen.gameObject.SetActive(true);
            UiManager.instance.GetUiGamePlayScreen.btn_Spin.gameObject.SetActive(true);
        }
        else {
            this.gameObject.SetActive(false);
            UiManager.instance.GetUiPowerupScreen.gameObject.SetActive(true);
            
          
        }
       
    }
}
