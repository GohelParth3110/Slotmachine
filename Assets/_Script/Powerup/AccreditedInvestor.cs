using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccreditedInvestor : MonoBehaviour
{
    [SerializeField] private SymbolData symbolData;
    private int baseValue;
    public int BaseValue;
    [SerializeField]private int count = 0;
    [SerializeField] private List<GameObject> list_Coin;
   
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
        count = 0;
        list_Coin.Clear();
        AdjucentData adjucentData = GetComponentInParent<AdjucentData>();
        for (int i = 0; i < adjucentData.all_Adjucent.Length; i++) {

            if (adjucentData.all_Adjucent[i].transform.childCount == 0) {
                continue;
            }
            SymbolData symbolData  = adjucentData.all_Adjucent[i].GetComponentInChildren<SymbolData>();
            if (!symbolData.enabled) {
                continue;
            }
            if (bitcoinSymboleIndex == adjucentData.all_Adjucent[i].GetComponentInChildren<SymbolData>().mySymbolIndex) {
                adjucentData.all_Adjucent[i].GetComponentInChildren<SymbolData>().enabled = false;
                list_Coin.Add(adjucentData.all_Adjucent[i].GetComponentInChildren<SymbolData>().gameObject);
                count++;
            }
            else if (cardanoCoinIndex == adjucentData.all_Adjucent[i].GetComponentInChildren<SymbolData>().mySymbolIndex) {
                adjucentData.all_Adjucent[i].GetComponentInChildren<SymbolData>().enabled = false;
                list_Coin.Add(adjucentData.all_Adjucent[i].GetComponentInChildren<SymbolData>().gameObject);
                count++;
            }
            else if (ethCoinSymboleIndex == adjucentData.all_Adjucent[i].GetComponentInChildren<SymbolData>().mySymbolIndex) {
                adjucentData.all_Adjucent[i].GetComponentInChildren<SymbolData>().enabled = false;
                list_Coin.Add(adjucentData.all_Adjucent[i].GetComponentInChildren<SymbolData>().gameObject);
                count++;

            }
            else if (stableCoinIndex == adjucentData.all_Adjucent[i].GetComponentInChildren<SymbolData>().mySymbolIndex) {
                adjucentData.all_Adjucent[i].GetComponentInChildren<SymbolData>().enabled = false;
                list_Coin.Add(adjucentData.all_Adjucent[i].GetComponentInChildren<SymbolData>().gameObject);
                count++;

            }

        }
        Debug.Log(list_Coin.Count);
        Debug.Log(list_Coin.Count % 2 == 0);
        
        if (list_Coin.Count%2==0) {
            BaseValue += 4 * (list_Coin.Count / 2);
            for (int i = 0; i < list_Coin.Count; i++) {
                list_Coin[i].GetComponentInParent<RawMotion>().VFXForMOtion();
                transform.GetComponentInParent<RawMotion>().VFXForMOtion();
                StartCoroutine(delayDestroy(list_Coin[i].gameObject));
            }
        }
        else {
            BaseValue += (4 * (list_Coin.Count-1))/2;
            for (int i = 0; i < list_Coin.Count-1; i++) {
                list_Coin[i].GetComponentInParent<RawMotion>().VFXForMOtion();
                transform.GetComponentInParent<RawMotion>().VFXForMOtion();
                StartCoroutine(delayDestroy(list_Coin[i].gameObject));
            }
            list_Coin[list_Coin.Count - 1].GetComponent<SymbolData>().enabled = true;
        }
    }


    private IEnumerator delayDestroy(GameObject coin) {
        yield return new WaitForSeconds(0.5f);
        GridManager.instance.RemoveGameObjectInList(coin);
    }
    private void Instance_SetCoinSetup(object sender, System.EventArgs e) {
        if (BaseValue <0) {
            BaseValue = 0;
        }
        CoinHandler.instance.SpawnCoin(BaseValue, transform.position);
        BaseValue = baseValue;
    }
    
}
