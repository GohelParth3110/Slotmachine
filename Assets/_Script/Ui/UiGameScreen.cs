using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

public class UiGameScreen : MonoBehaviour
{
    public Button btn_Spin;
    [SerializeField] private float flt_DelayOfTweSpin;
    

    private void Awake() {
        btn_Spin.onClick.AddListener(OnClickOnSpinBtnClick);
    }

    private void OnEnable() {
        CoinHandler.instance.RunCoinLoanAnimation();
    }

    private void OnClickOnSpinBtnClick() {

        GridManager.instance.SpinClick();
        btn_Spin.gameObject.SetActive(false);
      
    }

   

   
}
