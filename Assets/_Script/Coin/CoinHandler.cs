using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHandler : MonoBehaviour
{
    public static CoinHandler instance;
    [SerializeField] private GameObject coin;   
    [SerializeField] private float spawnDelay;   // When Event Pass Message Spawn Coin At That Time How Much delaay to Spawn Coin
    [SerializeField] private float afterSpawnDelay;
    [SerializeField] private float coinAnimationTime;  // how much Time To Coin Spawn Postition To Reached its  TargetPostion
    [SerializeField] private float coinTargetUpAnimationTime; // Time for Coin  up and Down Animation In Ui
    [SerializeField] private float DealyOfCoinDownAnimation;
    [SerializeField] private List<GameObject> List_Coin;
    [SerializeField] private List<int> list_flt_Ammount;
    private GameObject loanCoin;
    private void Awake() {
        instance = this;
    }
    
    // <summary>
    // first of all Spawn Coin
    // after Spawning Coin Coin Goes To TagretPostion and coin Up animation Also start
    // Coin Goes To Target Position Destroy Game Coin And Coin Down Animation Start
    // After Complete All Procedure powerup Screen Start
    // </Spawn>


    public void SpawnCoin(int Ammount ,Vector3 GridPosition) {

        if (Ammount == 0) {
            return;
        }
       
        // Dealy Of Spawn Coin due To Gamer See All Powerup
        StartCoroutine(DealySpawn(Ammount, GridPosition));
    }

    private IEnumerator DealySpawn(int Ammount, Vector3 GridPosition) {
        yield return new WaitForSeconds(spawnDelay);


       
        GameObject ThisCoin = Instantiate(coin, GridPosition, transform.rotation);
        ThisCoin.GetComponent<CoinAnimation>().SetCoinValue(Ammount);
        List_Coin.Add(ThisCoin);
       
       
    }
    public  void CoinAnimation() {

        for (int i = 0; i < List_Coin.Count; i++) {
           
            List_Coin[i].GetComponent<CoinAnimation>().SetAnimation( coinAnimationTime, afterSpawnDelay);
        }
        
        GameManager.instance.GetTargetofCoin().TargetUpAnimation(coinTargetUpAnimationTime);

        // delay for Coin Destroy  and Some More dealy For Gamer See Current Round Score
        StartCoroutine(CoinDownAnimation());
    }

    private IEnumerator CoinDownAnimation() {

        

        yield return new WaitForSeconds(coinAnimationTime + DealyOfCoinDownAnimation+ afterSpawnDelay);
     
        GameManager.instance.GetTargetofCoin().TargetDownAmiantion(coinTargetUpAnimationTime);
        GameManager.instance.GetTargetofCoin().resetCoin();
        list_flt_Ammount.Clear();
        List_Coin.Clear();

       

    }

   

   public float TotalTimeGetEvent() {
        float time = spawnDelay + afterSpawnDelay + coinAnimationTime + DealyOfCoinDownAnimation +coinTargetUpAnimationTime;
        return time;
   }

    public void SpawnCoinLoanTime(int Ammount, Vector3 GridPosition) {
        GameObject ThisCoin = Instantiate(coin, GridPosition, transform.rotation);
        ThisCoin.GetComponent<CoinAnimation>().SetCoinValue(Ammount);
        loanCoin = ThisCoin;
      
    }
    public  void RunCoinLoanAnimation() {

        if (loanCoin == null) {
            return;
        }

        loanCoin.GetComponent<CoinAnimation>().SetAnimation(coinAnimationTime, afterSpawnDelay);

        GameManager.instance.GetTargetofCoin().TargetUpAnimation(coinTargetUpAnimationTime);

        // delay for Coin Destroy  and Some More dealy For Gamer See Current Round Score
        StartCoroutine(CoinDownAnimation());
        StartCoroutine(DealaySpinBtnClick());
    }

    private IEnumerator DealaySpinBtnClick() {
        yield return new WaitForSeconds(coinAnimationTime + DealyOfCoinDownAnimation + afterSpawnDelay);
        UiManager.instance.GetUiGamePlayScreen.btn_Spin.gameObject.SetActive(true);
      
    }
}
