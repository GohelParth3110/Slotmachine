using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitCoin : MonoBehaviour
{
    private int baseValue;
    [SerializeField]private SymbolData symbolData;
    public bool IsStopRunning { get; set; }
    public int BaseValue { get; set; }

    private void OnEnable() {
        baseValue = symbolData.Basevalue;
        IsStopRunning = false;
        BaseValue = baseValue;
        GridManager.instance.SetCoinSetup += Instance_SetCoinSetup;
       
    }
    private void OnDisable() {
        GridManager.instance.SetCoinSetup -= Instance_SetCoinSetup;
    }

    private void Instance_SetCoinSetup(object sender, System.EventArgs e) {

        if (IsStopRunning) {
            return;
        }
        if (BaseValue<0) {
            BaseValue = 0;
        }
      
        CoinHandler.instance.SpawnCoin(BaseValue, transform.position);
        BaseValue = baseValue;
       
    }
    public void IncreasedPeminateBaseValue(int value) {
        if (IsStopRunning) {
            return;
        }
        baseValue += value;
        
    }
    public void PerminateValueZero() {
        if (IsStopRunning) {
            return;
        }
        baseValue = 0;
        BaseValue = 0;

    }



}
