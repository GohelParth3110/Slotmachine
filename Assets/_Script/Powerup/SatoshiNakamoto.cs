using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatoshiNakamoto : MonoBehaviour
{
    [SerializeField] private SymbolData symbolData;
    private int baseValue;

    private int vitalickSymboleIndex = 15;
    private int bitcoinSymboleIndex = 1;

    private void OnEnable() {
        baseValue = symbolData.Basevalue;
      
        GridManager.instance.SetCoinSetup += Instance_SetCoinSetup;
    }

  
    private void OnDisable() {

        GridManager.instance.SetCoinSetup -= Instance_SetCoinSetup;

    }
    public void Instance_SetDestroyeObj() {

       
        for (int i = 0; i < GridManager.instance.list_ActivateInHirachy.Count; i++) {
           

               // GameObject child = GridManager.instance.all_Postion[i].GetChild(0).gameObject;

                //if (child.TryGetComponent<Vitalick>(out Vitalick vitalick)) {

                //    Debug.Log("satoshinakamo Destroy vitralik");
                //    vitalick.IsStopRunning = true;
                //    StartCoroutine(DetroyVitalick(vitalick.gameObject));
                //    CoinHandler.instance.SpawnCoin(10, GridManager.instance.all_Postion[i].position);
                //}

                if (vitalickSymboleIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                   
                    GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();
                    transform.GetComponentInParent<RawMotion>().VFXForMOtion();
                    Vitalick vitalick = GridManager.instance.list_ActivateInHirachy[i].GetComponent<Vitalick>();
                   
                    vitalick.IsStopRunning = true;
                   

                    
                    StartCoroutine(delayDestroy(vitalick.gameObject));
                   
                    CoinHandler.instance.SpawnCoin(10, GridManager.instance.list_ActivateInHirachy[i].
                                            GetComponentInParent<Transform>().position);
                }

           
        }
    }

    private IEnumerator delayDestroy(GameObject vitalick)  {
        yield return new WaitForSeconds(0.5f);
        GridManager.instance.RemoveGameObjectInList(vitalick);
    }

    public void Instance_SetSynergy() {

      
        for (int i = 0; i < GridManager.instance.list_ActivateInHirachy.Count; i++) {

           

            if (bitcoinSymboleIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                    BitCoin bitCoin = GridManager.instance.list_ActivateInHirachy[i].GetComponent<BitCoin>();
                    bitCoin.BaseValue *= 3;
                   
                    GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();
                    transform.GetComponentInParent<RawMotion>().VFXForMOtion();
                }
            
        }

    }
    private void Instance_SetCoinSetup(object sender, System.EventArgs e) {
        CoinHandler.instance.SpawnCoin(baseValue, transform.position);
    }



}
