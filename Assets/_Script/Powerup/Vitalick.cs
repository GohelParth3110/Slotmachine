using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class Vitalick : MonoBehaviour
{
    [SerializeField] private SymbolData symbolData;
     private int baseValue;
    public int BaseValue { get; set; }
    public bool IsStopRunning { get; set; }
    [SerializeField] private int persenatgeofSpawnETh;

    private int ethCoinSymboleIndex = 2;

    private void OnEnable() {

        baseValue = symbolData.Basevalue;
        IsStopRunning = false;
        BaseValue = baseValue;
        GridManager.instance.SetSpawnObj += Instance_SetSpawnObj;
     
       GridManager.instance.SetCoinSetup += Instance_SetCoinSetup;
    }

   
    private void OnDisable() {

        GridManager.instance.SetSpawnObj -= Instance_SetSpawnObj;
        GridManager.instance.SetCoinSetup -= Instance_SetCoinSetup;
      
    }

    private void Instance_SetSpawnObj(object sender, EventArgs e) {

        int index = Random.Range(0, 100);
        if (index< persenatgeofSpawnETh) {
            GridManager.instance.OneExtraETHAddCoin();
        }
    
                 

    }


    public void Instance_SetSynergy() {

        AdjucentData adjucentData = GetComponentInParent<AdjucentData>();
        for (int i = 0; i < adjucentData.all_Adjucent.Length; i++) {

            if (adjucentData.all_Adjucent[i].transform.childCount != 0) {

              
                 if (ethCoinSymboleIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                    ETHCoin eTHCoin = GridManager.instance.list_ActivateInHirachy[i].GetComponent<ETHCoin>();
                    eTHCoin.BaseValue *= 2;
                    GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().StopAnimation();
                    transform.GetComponentInParent<RawMotion>().StopAnimation();
                }

            }

        }
    }




    private void Instance_SetCoinSetup(object sender, EventArgs e) {

        if (IsStopRunning) {
            return;
        }
        if (BaseValue<0) {
            BaseValue = 0;
        }
        Debug.Log("Vitalick Coin Spawn");
        CoinHandler.instance.SpawnCoin(BaseValue, transform.position);
        BaseValue = baseValue;

    }
}
