using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ASIC : MonoBehaviour
{
     private int baseValue;
    [SerializeField] private int persantageOfSpawnBitcoin;
    [SerializeField]private SymbolData symbolData;

    private void OnEnable() {
        baseValue = symbolData.Basevalue;
        GridManager.instance.SetSpawnObj += Instance_SetSpawnObj;
        GridManager.instance.SetCoinSetup += Instance_SetCoinSetup;
    }
    private void OnDisable() {

        GridManager.instance.SetSpawnObj -= Instance_SetSpawnObj;
        GridManager.instance.SetCoinSetup -= Instance_SetCoinSetup;
    }

    private void Instance_SetSpawnObj(object sender, System.EventArgs e) {
      
        
        int index = Random.Range(0, 100);
        if (index < persantageOfSpawnBitcoin) {
            GridManager.instance.OneExtraBitCoinAddCoin();
        }
    }
    private void Instance_SetCoinSetup(object sender, System.EventArgs e) {
        if (baseValue < 0) {
            baseValue = 0;
        }
        CoinHandler.instance.SpawnCoin(baseValue, transform.position);
    }
}
