using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auditor : MonoBehaviour
{
    [SerializeField] private SymbolData symbolData;
    public int BaseValue { get; set; }
    private int baseValue;
    private int cloudMiningIndex = 14;
    private int telegramScammerIndex = 28;
    private int crainNotRightIndex = 29;
    private int fomoBuyerIndex = 20;

    private void OnEnable() {
        baseValue = symbolData.mySymbolIndex;
        BaseValue = baseValue;  
        GridManager.instance.SetCoinSetup += Instance_SetCoinSetup;
    }

    

    private void OnDisable() {
    
        GridManager.instance.SetCoinSetup -= Instance_SetCoinSetup;
    }

    public   void Instance_SetDestroyeObj() {
        for (int i = 0; i < GridManager.instance.list_ActivateInHirachy.Count; i++) {
            if (cloudMiningIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {
                IncreasingPerminateValue(1);
                StartCoroutine(DealyDestroy(GridManager.instance.list_ActivateInHirachy[i].gameObject));
                transform.GetComponentInParent<RawMotion>().VFXForMOtion();
                GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();

            }
            else if (telegramScammerIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {
                IncreasingPerminateValue(1);
                StartCoroutine(DealyDestroy(GridManager.instance.list_ActivateInHirachy[i].gameObject));
                transform.GetComponentInParent<RawMotion>().VFXForMOtion();
                GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();
            }
            else if (crainNotRightIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {
                IncreasingPerminateValue(1);
                StartCoroutine(DealyDestroy(GridManager.instance.list_ActivateInHirachy[i].gameObject));
                transform.GetComponentInParent<RawMotion>().VFXForMOtion();
                GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();
            }
            else if (fomoBuyerIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {
                IncreasingPerminateValue(1);
                StartCoroutine(DealyDestroy(GridManager.instance.list_ActivateInHirachy[i].gameObject));
                transform.GetComponentInParent<RawMotion>().VFXForMOtion();
                GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();
            }
        }
    }

    private IEnumerator DealyDestroy(GameObject gameObject) {
        yield return new WaitForSeconds(0.5f);
        GridManager.instance.RemoveGameObjectInList(gameObject);
    }

    private void Instance_SetCoinSetup(object sender, System.EventArgs e) {
        if (BaseValue < 0) {
            BaseValue = 0;
        }
        CoinHandler.instance.SpawnCoin(BaseValue, transform.position);
    }

    public void IncreasingPerminateValue(int Ammount) {

        baseValue += Ammount;
        BaseValue = baseValue;
        
        
    }
}
