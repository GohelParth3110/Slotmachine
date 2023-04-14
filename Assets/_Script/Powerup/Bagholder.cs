using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bagholder : MonoBehaviour {

    [SerializeField] private SymbolData symbolData;
    private int baseValue;
    public int BaseValue { get; set; }
    private int count = 0;

    private void OnEnable() {
        baseValue = symbolData.Basevalue;
        BaseValue = baseValue;
       
        GridManager.instance.SetCoinSetup += Instance_SetCoinSetup;
    }

    private void OnDisable() {
        GridManager.instance.SetCoinSetup -= Instance_SetCoinSetup;
    }

    private void Instance_SetCoinSetup(object sender, System.EventArgs e) {
        count++;
        if (BaseValue<0) {
            BaseValue = 0;
        }
        CoinHandler.instance.SpawnCoin(BaseValue, transform.position);
    }

    public void Instance_SetSynergy() {

        if (count>3) {
            BaseValue = 1;
        }
    }
}
