using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandlestickGreen : MonoBehaviour
{
    private int baseValue;
    [SerializeField] private SymbolData symbolData;
    private int bitcoinSymboleIndex = 1;
    private int cardanoCoinIndex = 2;
    private int ethCoinSymboleIndex = 3;
    private int stableCoinIndex = 4;

    private void OnEnable() {
        baseValue = symbolData.Basevalue;
        GridManager.instance.SetCoinSetup += Instance_SetCoinSetup;
    }
    private void OnDisable() {


        GridManager.instance.SetCoinSetup -= Instance_SetCoinSetup;
    }



    public void Instance_SetSynergy() {

        AdjucentData adjucentData = transform.GetComponentInParent<AdjucentData>();
      
        for (int i = 0; i < adjucentData.all_Adjucent.Length; i++) {

           
            if (adjucentData.all_Adjucent[i].transform.childCount==0) {
                continue;
            }

            if (bitcoinSymboleIndex == adjucentData.all_Adjucent[i].GetComponentInChildren<SymbolData>().mySymbolIndex) {

                BitCoin bitCoin = adjucentData.all_Adjucent[i].GetComponentInChildren<BitCoin>();
                bitCoin.BaseValue += 1;
                adjucentData.all_Adjucent[i].GetComponent<RawMotion>().VFXForMOtion();
                transform.GetComponentInParent<RawMotion>().VFXForMOtion();
            }
            else if (cardanoCoinIndex == adjucentData.all_Adjucent[i].GetComponentInChildren<SymbolData>().mySymbolIndex) {

                CardanoCoin cardanoCoin = adjucentData.all_Adjucent[i].GetComponentInChildren<CardanoCoin>();
                cardanoCoin.BaseValue += 1;
                adjucentData.all_Adjucent[i].GetComponent<RawMotion>().VFXForMOtion();
                transform.GetComponentInParent<RawMotion>().VFXForMOtion();
            }
            else if (ethCoinSymboleIndex == adjucentData.all_Adjucent[i].GetComponentInChildren<SymbolData>().mySymbolIndex) {

                ETHCoin eTHCoin = adjucentData.all_Adjucent[i].GetComponentInChildren<ETHCoin>();
                eTHCoin.BaseValue += 1;
                adjucentData.all_Adjucent[i].GetComponent<RawMotion>().VFXForMOtion();
                transform.GetComponentInParent<RawMotion>().VFXForMOtion();
            }
            else if (stableCoinIndex == adjucentData.all_Adjucent[i].GetComponentInChildren<SymbolData>().mySymbolIndex) {

                StableCoin stableCoin = adjucentData.all_Adjucent[i].GetComponentInChildren<StableCoin>();
                stableCoin.BaseValue += 1;
                adjucentData.all_Adjucent[i].GetComponent<RawMotion>().VFXForMOtion();
                transform.GetComponentInParent<RawMotion>().VFXForMOtion();
            }


        }
    }

    private void Instance_SetCoinSetup(object sender, System.EventArgs e) {
        CoinHandler.instance.SpawnCoin(baseValue, transform.position);
    }
}
