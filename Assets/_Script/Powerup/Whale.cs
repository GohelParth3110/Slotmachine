using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whale : MonoBehaviour
{
    [SerializeField] private SymbolData symbolData;
     private int baseValue;
    [SerializeField] private int extraValue;

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

    public void Instance_SetDestroyeObj() {
        extraValue = 0;
        for (int i = 0; i < GridManager.instance.list_ActivateInHirachy.Count; i++) {

            

                if (bitcoinSymboleIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                    BitCoin bitCoin = GridManager.instance.list_ActivateInHirachy[i].GetComponent<BitCoin>();
                    extraValue++;
                    bitCoin.IsStopRunning = true;
                    StartCoroutine(DestroyObject(bitCoin.gameObject));
                    GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();
                    transform.GetComponentInParent<RawMotion>().VFXForMOtion();
                }
                else if (cardanoCoinIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                    CardanoCoin cardanoCoin = GridManager.instance.list_ActivateInHirachy[i].GetComponent<CardanoCoin>();

                    extraValue++;
                    cardanoCoin.IsStopRunning = true;
                    StartCoroutine(DestroyObject(cardanoCoin.gameObject));
                    GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();
                    transform.GetComponentInParent<RawMotion>().VFXForMOtion();

                }
                else if (ethCoinSymboleIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                    ETHCoin eTHCoin = GridManager.instance.list_ActivateInHirachy[i].GetComponent<ETHCoin>();

                    extraValue++;
                    eTHCoin.IsStopRunning = true;
                    StartCoroutine(DestroyObject(eTHCoin.gameObject));
                    GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();
                    transform.GetComponentInParent<RawMotion>().VFXForMOtion();

                }
                else if (stableCoinIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                    StableCoin stableCoin = GridManager.instance.list_ActivateInHirachy[i].GetComponent<StableCoin>();
                    extraValue++;
                    stableCoin.IsStopRunning = true;
                    StartCoroutine(DestroyObject(stableCoin.gameObject));
                    GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();
                    transform.GetComponentInParent<RawMotion>().VFXForMOtion();
                }

            
        }
        
    }

    private IEnumerator DestroyObject(GameObject child) {
        yield return new WaitForSeconds(1);
        GridManager.instance.RemoveGameObjectInList(child);
       
    }

  

    private void Instance_SetCoinSetup(object sender, System.EventArgs e) {
        CoinHandler.instance.SpawnCoin(baseValue + extraValue, transform.position);
    }

}
