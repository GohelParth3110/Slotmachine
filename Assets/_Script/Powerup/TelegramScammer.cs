using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelegramScammer : MonoBehaviour
{
    [SerializeField] private SymbolData symbolData;
     private int baseValue;
    [SerializeField] private int stolenValue;

    private int vitalickSymboleIndex = 15;
    private int fomoBuyerIndex = 8;
    private int HodlerIndex = 9;
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

        // Undefine;
    }

    public void Instance_SetSynergy() {
        for (int i = 0; i < GridManager.instance.list_ActivateInHirachy.Count; i++) {
      

                if (fomoBuyerIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                    FomoBuyer fomoBuyer = GridManager.instance.list_ActivateInHirachy[i].GetComponent<FomoBuyer>();
                    fomoBuyer.BaseValue -= 1;
                    stolenValue += 1;
                    GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().StopAnimation();
                    transform.GetComponentInParent<RawMotion>().StopAnimation();
                }
                else if (HodlerIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                    Hodler hodler = GridManager.instance.list_ActivateInHirachy[i].GetComponent<Hodler>();
                    hodler.BaseValue -= 1;
                    stolenValue += 1;
                    GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().StopAnimation();
                    transform.GetComponentInParent<RawMotion>().StopAnimation();
                }
                else if (vitalickSymboleIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                    Vitalick vitalick = GridManager.instance.list_ActivateInHirachy[i].GetComponent<Vitalick>();
                    vitalick.BaseValue -= 1;
                    stolenValue += 1;
                    GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().StopAnimation();
                    transform.GetComponentInParent<RawMotion>().StopAnimation();

                }

            

        }
    }
    private void Instance_SetCoinSetup(object sender, System.EventArgs e) {

        CoinHandler.instance.SpawnCoin(baseValue, transform.position);
        Debug.Log("StolenValue" + stolenValue);
    }

   
}
