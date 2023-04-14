using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StableCoin : MonoBehaviour
{
    [SerializeField]private SymbolData symbolData;
    private int baseValue;
    public int BaseValue { get; set; }
    public bool IsStopRunning { get; set; }

    private void OnEnable() {
        baseValue = symbolData.Basevalue;
        IsStopRunning = false;
        GridManager.instance.SetCoinSetup += Instance_SetCoinSetup;
        BaseValue = baseValue;
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

    public void SetFomoBuyerCoin(int value) {
        if (IsStopRunning) {
            return;
        }
        CoinHandler.instance.SpawnCoin(value, transform.position);
    }
    public void IncreasedPeminateBaseValue(int value) {
        if (IsStopRunning) {
            return;
        }
        baseValue += value;
        BaseValue = baseValue;
    }
    public void PerminateValueZero() {
        if (IsStopRunning) {
            return;
        }
        baseValue = 0;
        BaseValue = baseValue;

    }

}
