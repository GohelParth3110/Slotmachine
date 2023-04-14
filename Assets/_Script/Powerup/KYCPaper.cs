using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KYCPaper : MonoBehaviour
{
    [SerializeField] private SymbolData symbolData;
     private int baseValue;
    private int fomoBuyerIndex = 8;
    private int HodlerIndex = 9;

    private void OnEnable() {

        baseValue = symbolData.Basevalue;
      
        GridManager.instance.SetCoinSetup += Instance_SetCoinSetup;
    }
    private void OnDisable() {

       
        GridManager.instance.SetCoinSetup -= Instance_SetCoinSetup;
    }

   
    public void Instance_SetSynergy(object sender, EventArgs e) {

        AdjucentData adjucentData = GetComponentInParent<AdjucentData>();
        for (int i = 0; i < adjucentData.all_Adjucent.Length; i++) {

            if (adjucentData.all_Adjucent[i].transform.childCount != 0) {

                if (fomoBuyerIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                    FomoBuyer fomoBuyer = GridManager.instance.list_ActivateInHirachy[i].GetComponent<FomoBuyer>();
                    fomoBuyer.BaseValue += 1;
                    GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();
                    transform.GetComponentInParent<RawMotion>().VFXForMOtion();
                }
                else if (HodlerIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                    Hodler hodler = GridManager.instance.list_ActivateInHirachy[i].GetComponent<Hodler>();
                    hodler.BaseValue += 1;
                    GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();
                    transform.GetComponentInParent<RawMotion>().VFXForMOtion();
                }
               

            }

        }
    }
    private void Instance_SetCoinSetup(object sender, EventArgs e) {

        CoinHandler.instance.SpawnCoin(baseValue, transform.position);
    }

}
