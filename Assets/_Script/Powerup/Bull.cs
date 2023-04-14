using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bull : MonoBehaviour
{
     private int baseValue;
    [SerializeField] private SymbolData symbolData;
    private int bitcoinSymboleIndex = 1;
    private int cardanoCoinIndex = 2;
    private int ethCoinSymboleIndex = 3;
    private int stableCoinIndex = 4;


    private void OnEnable() {
        baseValue = symbolData.Basevalue;
      
        GridManager.instance.SetCoinSetup += Instance_SetCoinSetup;
    }
    private void OnDisable() {

       
        GridManager.instance.SetCoinSetup -= Instance_SetCoinSetup;
    }



    public void Instance_SetSynergy() {

        for (int i = 0; i < GridManager.instance.list_ActivateInHirachy.Count; i++) {



                if (bitcoinSymboleIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                    BitCoin bitCoin = GridManager.instance.list_ActivateInHirachy[i].GetComponent<BitCoin>();
                    bitCoin.BaseValue += 1;
                    Debug.Log("BitcoinBasvelue : " + bitCoin.BaseValue + "Increseing By Bull");
                    GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();
                    transform.GetComponentInParent<RawMotion>().VFXForMOtion();
                }
                else if (cardanoCoinIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                CardanoCoin caradnoCoin = GridManager.instance.list_ActivateInHirachy[i].GetComponent<CardanoCoin>();
                caradnoCoin.BaseValue += 1;
                GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();
                transform.GetComponentInParent<RawMotion>().VFXForMOtion();
                }
                else if (ethCoinSymboleIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                    ETHCoin eTHCoin = GridManager.instance.list_ActivateInHirachy[i].GetComponent<ETHCoin>();
                    eTHCoin.BaseValue += 1;
                    GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();
                    transform.GetComponentInParent<RawMotion>().VFXForMOtion();
                }
                else if (stableCoinIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                    StableCoin stableCoin = GridManager.instance.list_ActivateInHirachy[i].GetComponent<StableCoin>();
                    stableCoin.BaseValue += 1;
                    GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();
                    transform.GetComponentInParent<RawMotion>().VFXForMOtion();
                }
            

        }
    }

    private void Instance_SetCoinSetup(object sender, System.EventArgs e) {
        CoinHandler.instance.SpawnCoin(baseValue, transform.position);
    }

   
}
