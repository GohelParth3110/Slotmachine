using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xpowerup : MonoBehaviour
{
    [SerializeField] private SymbolData symbolData;
    [SerializeField] private int baseValue = 0;

    private void OnEnable() {
        baseValue = symbolData.Basevalue;
       
        GridManager.instance.SetCoinSetup += Instance_SetCoinSetup;
    }
    private void OnDisable() {

       
        GridManager.instance.SetCoinSetup -= Instance_SetCoinSetup;
    }

    public void Instance_SetDestroyeObj() {
        baseValue = 0;
        AdjucentData adjucentData = GetComponentInParent<AdjucentData>();
        for (int i = 0; i < adjucentData.all_Adjucent.Length; i++) {

            if (adjucentData.all_Adjucent[i].transform.childCount != 0) {

                baseValue++;
            }

        }
        if (baseValue == 0) {

            StartCoroutine(Destroy());
          
        }
       
    }

    private IEnumerator Destroy() {

        yield return new WaitForSeconds(1);
        GridManager.instance.RemoveGameObjectInList(gameObject);


    }

    private void Instance_SetCoinSetup(object sender, EventArgs e) {
        if (baseValue  == 0) {
            return;
        }
        CoinHandler.instance.SpawnCoin(baseValue, transform.position);
    }

   
   
}
