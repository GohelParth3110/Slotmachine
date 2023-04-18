using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;
using UnityEngine.UI;


public class UIPowerup : MonoBehaviour {

   
  
    [SerializeField] private TextMeshProUGUI txt_RentCoin;
    [SerializeField] private TextMeshProUGUI txt_RemaingValue;
    [SerializeField] private TextMeshProUGUI txt_CurrentSpin;
    [SerializeField] private TextMeshProUGUI txt_CurrentLevelCollectedCoin;
    [SerializeField] private List<int> all_CurrentPowerupIndex;
    [SerializeField] private Button btn_Skip;
    [SerializeField] private Button btn_Reload;
    [SerializeField] private TextMeshProUGUI txt_NextReloadValue;
    [SerializeField] private int reloadValue;
    [SerializeField] private int currentReloadValue;
    [SerializeField]private List<GameObject> list_ThisTimePowerup;
    [SerializeField] private GameObject[] all_PowerUpPenal;

    public bool IsLevelChangeTime { get; set; }

    private void Awake() {

        btn_Skip.onClick.AddListener(OnClickOnSkipBtn);
        btn_Reload.onClick.AddListener(OnClickOnReloadBtnClick);
        
    }

    private void OnClickOnSkipBtn() {
      
        if (IsLevelChangeTime) {
           
            UiManager.instance.GetUIPassiveScreen.gameObject.SetActive(true);
            IsLevelChangeTime = false;
        }
        else {
           
            UiManager.instance.GetUiGamePlayScreen.gameObject.SetActive(true);
            UiManager.instance.GetUiGamePlayScreen.btn_Spin.gameObject.SetActive(true);
            for (int i = 0; i < GridManager.instance.list_ActivateInHirachy.Count; i++) {
                if (GridManager.instance.list_ActivateInHirachy[i].TryGetComponent<CrossChain>(out CrossChain crossChain)) {
                    crossChain.IsSwap = true;
                    Debug.Log(crossChain.IsSwap);
                }
            }
        }
        this.gameObject.SetActive(false);
        GridManager.instance.SkipTimeObjectSetup();

    }

    private void OnClickOnReloadBtnClick() {


        if (GameManager.instance.Score < currentReloadValue +1) {
            return;
        }

        GameManager.instance.UpdateScore(-currentReloadValue);
        txt_CurrentLevelCollectedCoin.text = GameManager.instance.Score.ToString();
        currentReloadValue += reloadValue;
        txt_NextReloadValue.text = currentReloadValue.ToString();
        SetAllPowerUp();
       
    }

    private void OnEnable() {
       

        SetAllPowerUp();
        currentReloadValue = reloadValue;
        txt_NextReloadValue.text = currentReloadValue +  " $ ";
        txt_CurrentLevelCollectedCoin.text = GameManager.instance.Score.ToString();
        txt_RentCoin.text = LevelManager.instance.CurrentLevel.RentValue.ToString();
        txt_CurrentSpin.text = LevelManager.instance.CurrentSpin.ToString();
        txt_RemaingValue.text = (LevelManager.instance.CurrentLevel.SpinValue - LevelManager.instance.CurrentSpin).ToString();


    }

    private void SetAllPowerUp() {

        list_ThisTimePowerup.Clear();
        for (int i = 0; i < all_PowerUpPenal.Length; i++) {
            if (all_PowerUpPenal[i].gameObject.activeSelf) {
                all_PowerUpPenal[i].gameObject.SetActive(false);
            }
        }
        for (int i = 0; i < all_PowerUpPenal.Length; i++) {
            list_ThisTimePowerup.Add(all_PowerUpPenal[i]);
        }
        for (int i = 0; i < 4; i++) {

            int index = Random.Range(0, list_ThisTimePowerup.Count);

            list_ThisTimePowerup[index].gameObject.SetActive(true);
            list_ThisTimePowerup.RemoveAt(index);
        }

    }

    public void OnClickOnPowerbtnClick(int index) {

      
       
        GridManager.instance.EveryWaveSpawnOneObj(PowerupManager.instance.all_SymbolData[index].gameObject);
        SetPowerup();
       
        if (IsLevelChangeTime) {
            UiManager.instance.GetUIPassiveScreen.gameObject.SetActive(true);
            IsLevelChangeTime = false;
        }
        else {
            UiManager.instance.GetUiGamePlayScreen.gameObject.SetActive(true);
            UiManager.instance.GetUiGamePlayScreen.btn_Spin.gameObject.SetActive(true);
            for (int i = 0; i < GridManager.instance.list_ActivateInHirachy.Count; i++) {
                     if (GridManager.instance.list_ActivateInHirachy[i].TryGetComponent<CrossChain>(out CrossChain crossChain)) {
                    crossChain.IsSwap = true;
                    Debug.Log(crossChain.IsSwap);
                }
            }
        }
        this.gameObject.SetActive(false);
    }


    


    private void SetPowerup() {

        if (PowerupManager.instance.dexHandling.Count == 0) {
            return;
        }

        for (int i = 0; i < PowerupManager.instance.dexHandling.Count; i++) {

            if (PowerupManager.instance.dexHandling[i].gameObject.activeSelf) {
                PowerupManager.instance.dexHandling[i].SetSwapProcess();

            }

        }


        
    }

   
}
