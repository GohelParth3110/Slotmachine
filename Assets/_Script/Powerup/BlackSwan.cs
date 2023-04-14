using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackSwan : MonoBehaviour
{
    [SerializeField] private SymbolData symbolData;
    [SerializeField] private int baseValue;
    public int BaseValue { get; set; }  // thisWave

    private int bitcoinSymboleIndex = 1;
    private int cardanoCoinIndex = 2;
    private int ethCoinSymboleIndex = 3;
    private int stableCoinIndex = 4;

    private void OnEnable() {
        baseValue = symbolData.Basevalue;
        BaseValue = baseValue;
        GridManager.instance.SetCoinSetup += Instance_SetCoinSetup;
    }
    private void OnDisable() {
        GridManager.instance.SetCoinSetup -= Instance_SetCoinSetup;
    }

    public void Instance_SetSynergy() {

        for (int i = 0; i < GridManager.instance.list_ActivateInHirachy.Count; i++) {

            if (bitcoinSymboleIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                BitCoin bitCoin = GridManager.instance.list_ActivateInHirachy[i].GetComponent<BitCoin>();
                bitCoin.BaseValue  =  0;
                GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();
                transform.GetComponentInParent<RawMotion>().VFXForMOtion();
            }
            else if (cardanoCoinIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {
                CardanoCoin cardanoCoin = GridManager.instance.list_ActivateInHirachy[i].GetComponent<CardanoCoin>();
                cardanoCoin.BaseValue = 0;
                GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();
                transform.GetComponentInParent<RawMotion>().VFXForMOtion();
            }
            else if (ethCoinSymboleIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                ETHCoin eTHCoin = GridManager.instance.list_ActivateInHirachy[i].GetComponent<ETHCoin>();
                eTHCoin.BaseValue  = 0;
                GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();
                transform.GetComponentInParent<RawMotion>().VFXForMOtion();
            }
            else if (stableCoinIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                StableCoin stableCoin = GridManager.instance.list_ActivateInHirachy[i].GetComponent<StableCoin>();
                stableCoin.BaseValue  = 0;
                GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();
                transform.GetComponentInParent<RawMotion>().VFXForMOtion();
            }
        }
    }

    private void Instance_SetCoinSetup(object sender, System.EventArgs e) {
        if (BaseValue<0) {
            BaseValue = 0;
        }
        CoinHandler.instance.SpawnCoin(BaseValue, transform.position);
    }
}
