using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMining : MonoBehaviour
{
    private int baseValue;
    [SerializeField] private SymbolData symbolData;
    [SerializeField] private int persantageOFSpawnBitCoin;
    [SerializeField] private int persantageOfDestroyAllCoin;
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

    public void Instance_SetSpawnObj() {
        int index = Random.Range(0, 100);
        if (index < persantageOFSpawnBitCoin) {
            GridManager.instance.OneExtraBitCoinAddCoin();
        }
    }
    public void Instance_SetDestroyeObj() {
        int index = Random.Range(0, 100);
        if (index<persantageOfDestroyAllCoin) {

            for (int i = 0; i < GridManager.instance.list_ActivateInHirachy.Count; i++) {

                if (bitcoinSymboleIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {
                    GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();
                    transform.GetComponentInParent<RawMotion>().VFXForMOtion();
                    BitCoin bitcoin = GridManager.instance.list_ActivateInHirachy[i].GetComponent<BitCoin>();
                    bitcoin.IsStopRunning = true;
                    StartCoroutine(delayDestroy(bitcoin.gameObject));

                }
                else if (cardanoCoinIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {
                    GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();
                    transform.GetComponentInParent<RawMotion>().VFXForMOtion();
                    CardanoCoin cardanoCoin = GridManager.instance.list_ActivateInHirachy[i].GetComponent<CardanoCoin>();
                    cardanoCoin.IsStopRunning = true;
                    StartCoroutine(delayDestroy(cardanoCoin.gameObject));
                }
                else if (ethCoinSymboleIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {
                    GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();
                    transform.GetComponentInParent<RawMotion>().VFXForMOtion();
                    ETHCoin ethcoin = GridManager.instance.list_ActivateInHirachy[i].GetComponent<ETHCoin>();
                    ethcoin.IsStopRunning = true;
                    StartCoroutine(delayDestroy(ethcoin.gameObject));
                }
                else if (stableCoinIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {
                    GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();
                    transform.GetComponentInParent<RawMotion>().VFXForMOtion();
                    StableCoin stableCoin = GridManager.instance.list_ActivateInHirachy[i].GetComponent<StableCoin>();
                    stableCoin.IsStopRunning = true;
                    StartCoroutine(delayDestroy(stableCoin.gameObject));
                }
            }

        }
    }
    private IEnumerator delayDestroy(GameObject coin) {
        yield return new WaitForSeconds(0.5f);
        GridManager.instance.RemoveGameObjectInList(coin);
    }


    private void Instance_SetCoinSetup(object sender, System.EventArgs e) {
        CoinHandler.instance.SpawnCoin(baseValue, transform.position);
    }



}
