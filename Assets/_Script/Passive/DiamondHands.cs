using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondHands : MonoBehaviour
{
  
    [SerializeField]private int baseValue;
   
   
    [SerializeField] private List<GameObject> list_Coin;

    private int bitcoinSymboleIndex = 1;
    private int cardanoCoinIndex = 2;
    private int ethCoinSymboleIndex = 3;
    private int stableCoinIndex = 4;

    private void OnEnable() {
       
        GridManager.instance.SetCoinSetup += Instance_SetCoinSetup;
    }



    private void OnDisable() {
      
        GridManager.instance.SetCoinSetup -= Instance_SetCoinSetup;
    }

   

    public void Instance_SetSynergy() {
        baseValue = 0;
        list_Coin.Clear();
      
        for (int i = 0; i < GridManager.instance.list_ActivateInHirachy.Count; i++) {

          

            if (bitcoinSymboleIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                list_Coin.Add(GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().gameObject);

            }
            else if (cardanoCoinIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {
                list_Coin.Add(GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().gameObject);

            }
            else if (ethCoinSymboleIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {
                list_Coin.Add(GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().gameObject);


            }
            else if (stableCoinIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {
                list_Coin.Add(GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().gameObject);


            }

        }

     
            baseValue += (list_Coin.Count / 3);

      
    }

    private void Instance_SetCoinSetup(object sender, System.EventArgs e) {
        CoinHandler.instance.SpawnCoin(baseValue, transform.position);
       
    }
}
