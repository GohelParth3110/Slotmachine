using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MichaelSaylor : MonoBehaviour
{
     private int baseValue;
    [SerializeField] private SymbolData symbolData;
    private int bitcoinSymboleIndex = 1;
    

    private void OnEnable() {

        baseValue = symbolData.Basevalue;
        GridManager.instance.SetDestroyeObj += Instance_SetDestroyeObj;
        GridManager.instance.SetCoinSetup += Instance_SetCoinSetup;
    }


    private void OnDisable() {

        GridManager.instance.SetDestroyeObj -= Instance_SetDestroyeObj;
        GridManager.instance.SetCoinSetup -= Instance_SetCoinSetup;

    }
    private void Instance_SetDestroyeObj(object sender, System.EventArgs e) {

        for (int i = 0; i < GridManager.instance.list_ActivateInHirachy.Count; i++) {
           
            
                if (bitcoinSymboleIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {
                    GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().StopAnimation();
                    transform.GetComponentInParent<RawMotion>().StopAnimation();
                    BitCoin bitCoin = GridManager.instance.list_ActivateInHirachy[i].GetComponent<BitCoin>();
                    bitCoin.IncreasedPeminateBaseValue(1);
                    bitCoin.IsStopRunning = true;
                    StartCoroutine(Destroyed(bitCoin.gameObject));
                }
           
        }
    }

    private IEnumerator Destroyed(GameObject child) {
        yield return new WaitForSeconds(1);
        GridManager.instance.RemoveGameObjectInList(child);

    }

    private void Instance_SetCoinSetup(object sender, System.EventArgs e) {
        CoinHandler.instance.SpawnCoin(baseValue, transform.position);
    }


}
