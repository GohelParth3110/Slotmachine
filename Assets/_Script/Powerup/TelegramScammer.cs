using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelegramScammer : MonoBehaviour
{
    [SerializeField] private SymbolData symbolData;
     private int baseValue;
    [SerializeField] private int stolenValue;

    private int vitalickSymboleIndex = 29;
    private int fomoBuyerIndex = 20;
    private int HodlerIndex = 22;
    private void OnEnable() {

        baseValue = symbolData.Basevalue;
      
        
        GridManager.instance.SetCoinSetup += Instance_SetCoinSetup;
    }

    private void OnDisable() {

      
       
        GridManager.instance.SetCoinSetup -= Instance_SetCoinSetup;
    }

    public void Instance_SetDestroyeObj() {

        // Undefine;
    }

    public void Instance_SetSynergy() {
        for (int i = 0; i < GridManager.instance.list_ActivateInHirachy.Count; i++) {
      

                if (fomoBuyerIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                    FomoBuyer fomoBuyer = GridManager.instance.list_ActivateInHirachy[i].GetComponent<FomoBuyer>();
                    fomoBuyer.BaseValue -= 1;
                    stolenValue += 1;
                    GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();
                    transform.GetComponentInParent<RawMotion>().VFXForMOtion();
                }
                else if (HodlerIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                    Hodler hodler = GridManager.instance.list_ActivateInHirachy[i].GetComponent<Hodler>();
                    hodler.BaseValue -= 1;
                    stolenValue += 1;
                    GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();
                    transform.GetComponentInParent<RawMotion>().VFXForMOtion();
                }
                else if (vitalickSymboleIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                    Vitalick vitalick = GridManager.instance.list_ActivateInHirachy[i].GetComponent<Vitalick>();
                    vitalick.BaseValue -= 1;
                    stolenValue += 1;
                    GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();
                    transform.GetComponentInParent<RawMotion>().VFXForMOtion();

                }

            

        }
    }
    private void Instance_SetCoinSetup(object sender, System.EventArgs e) {

        CoinHandler.instance.SpawnCoin(baseValue, transform.position);
        Debug.Log("StolenValue" + stolenValue);
    }

   
}
