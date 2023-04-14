using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FomoBuyer : MonoBehaviour
{
    [SerializeField] private SymbolData symbolData;
     private int baseValue;
    public int BaseValue { get; set; }

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

        AdjucentData adjucentData = GetComponentInParent<AdjucentData>();
        for (int i = 0; i < adjucentData.all_Adjucent.Length; i++) {

            if (adjucentData.all_Adjucent[i].transform.childCount != 0) {

               

                if (bitcoinSymboleIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                    BitCoin bitCoin = GridManager.instance.list_ActivateInHirachy[i].GetComponent<BitCoin>();
                    bitCoin.BaseValue *= 2;
                    GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();
                    transform.GetComponentInParent<RawMotion>().VFXForMOtion();
                }
                else if (cardanoCoinIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                    CardanoCoin caradnoCoin = GridManager.instance.list_ActivateInHirachy[i].GetComponent<CardanoCoin>();
                    caradnoCoin.BaseValue *= 2;
                    GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();
                    transform.GetComponentInParent<RawMotion>().VFXForMOtion();
                }
                else if (ethCoinSymboleIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                    ETHCoin eTHCoin = GridManager.instance.list_ActivateInHirachy[i].GetComponent<ETHCoin>();
                    eTHCoin.BaseValue *= 2;
                    GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();
                    transform.GetComponentInParent<RawMotion>().VFXForMOtion();
                }
                else if (stableCoinIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                    StableCoin stableCoin = GridManager.instance.list_ActivateInHirachy[i].GetComponent<StableCoin>();
                    stableCoin.BaseValue *= 2;
                    GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();
                    transform.GetComponentInParent<RawMotion>().VFXForMOtion();
                }

            }

        }
    }

   

    private void Instance_SetCoinSetup(object sender, EventArgs e) {

        if (BaseValue<0) {
            baseValue = 0;
        }
        CoinHandler.instance.SpawnCoin(BaseValue, transform.position);
        BaseValue = baseValue;
    }


  
}
