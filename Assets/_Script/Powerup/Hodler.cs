using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hodler : MonoBehaviour
{
    [SerializeField] private SymbolData symbolData;
     private int   baseValue;
    [SerializeField] private int CurrentNoofSpin = 0;
    [SerializeField] private int ChangeNoOfSpin;

    public int BaseValue { get; set; }

    private void OnEnable() {
        baseValue = symbolData.Basevalue;
        BaseValue = baseValue;
        GridManager.instance.SetCoinSetup += Instance_SetCoinSetup;
    }
    private void OnDisable() {
        GridManager.instance.SetCoinSetup -= Instance_SetCoinSetup;
    }

    private void Instance_SetCoinSetup(object sender, System.EventArgs e) {

        CurrentNoofSpin++;
        if (CurrentNoofSpin >= ChangeNoOfSpin) {
            baseValue += 1;
            CurrentNoofSpin = 0;
        }
        if (BaseValue<0) {
            BaseValue = 0;
        }
        CoinHandler.instance.SpawnCoin(BaseValue, transform.position);
        BaseValue = baseValue;

    }
}
