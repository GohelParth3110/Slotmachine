using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loan : MonoBehaviour
{
    
    [SerializeField]private int count;
   
    [SerializeField] private int moneyReturnCount;
   

    private void OnEnable() {
        
        GridManager.instance.SetCoinSetup += Instance_SetCoinSetup;
    }
    private void OnDisable() {
        GridManager.instance.SetCoinSetup -= Instance_SetCoinSetup;
    }

    private void Instance_SetCoinSetup(object sender, System.EventArgs e) {
       
            count++;
        
        if (count>= moneyReturnCount ) {
            CoinHandler.instance.SpawnCoin(-75, transform.position);
        }
    }

  

   
}
