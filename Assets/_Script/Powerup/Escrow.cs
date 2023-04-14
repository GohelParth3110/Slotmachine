using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escrow : MonoBehaviour {
    [SerializeField] private SymbolData symbolData;
    [SerializeField]private int baseValue;
    public int BaseValue { get;set; }
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

    public void Instance_SetDestroyeObj() {

        AdjucentData adjucentData = transform.GetComponentInParent<AdjucentData>();
        for (int i = 0; i < adjucentData.all_Adjucent.Length; i++) {

            if (adjucentData.all_Adjucent[i].transform.childCount == 0) {
                continue;
            }


            if (bitcoinSymboleIndex == adjucentData.all_Adjucent[i].GetComponentInChildren<SymbolData>().mySymbolIndex) {

                BitCoin bitCoin = adjucentData.all_Adjucent[i].GetComponentInChildren<BitCoin>();
                IncreasedPeminateBaseValue(1);
                StartCoroutine(delayDestroy(bitCoin.gameObject));
                adjucentData.all_Adjucent[i].GetComponent<RawMotion>().VFXForMOtion();
                transform.GetComponentInParent<RawMotion>().VFXForMOtion();
            }
            else if (cardanoCoinIndex == adjucentData.all_Adjucent[i].GetComponentInChildren<SymbolData>().mySymbolIndex) {

                CardanoCoin cardanoCoin = adjucentData.all_Adjucent[i].GetComponentInChildren<CardanoCoin>();
                IncreasedPeminateBaseValue(1);
                StartCoroutine(delayDestroy(cardanoCoin.gameObject));
                adjucentData.all_Adjucent[i].GetComponent<RawMotion>().VFXForMOtion();
                transform.GetComponentInParent<RawMotion>().VFXForMOtion();
            }
            else if (ethCoinSymboleIndex == adjucentData.all_Adjucent[i].GetComponentInChildren<SymbolData>().mySymbolIndex) {

                ETHCoin eTHCoin = adjucentData.all_Adjucent[i].GetComponentInChildren<ETHCoin>();
                IncreasedPeminateBaseValue(1);
                StartCoroutine(delayDestroy(eTHCoin.gameObject));
                adjucentData.all_Adjucent[i].GetComponent<RawMotion>().VFXForMOtion();
                transform.GetComponentInParent<RawMotion>().VFXForMOtion();
            }
            else if (stableCoinIndex == adjucentData.all_Adjucent[i].GetComponentInChildren<SymbolData>().mySymbolIndex) {

                StableCoin stableCoin = adjucentData.all_Adjucent[i].GetComponentInChildren<StableCoin>();
                IncreasedPeminateBaseValue(1);
                StartCoroutine(delayDestroy(stableCoin.gameObject));
                adjucentData.all_Adjucent[i].GetComponent<RawMotion>().VFXForMOtion();
                transform.GetComponentInParent<RawMotion>().VFXForMOtion();
            }
            // Scammer
        }

    }
    private IEnumerator delayDestroy(GameObject coin) {
        yield return new WaitForSeconds(0.5f);
        GridManager.instance.RemoveGameObjectInList(coin);
    }
    private void Instance_SetCoinSetup(object sender, System.EventArgs e) {
        if (BaseValue<0) {
            BaseValue = 0;
        }
        CoinHandler.instance.SpawnCoin(BaseValue, transform.position);
    }
    public void IncreasedPeminateBaseValue(int value) {
        
        baseValue += value;
        BaseValue = baseValue;
    }
}

    
