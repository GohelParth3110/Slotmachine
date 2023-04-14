using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;
using UnityEngine.UI;


public class UIPowerup : MonoBehaviour {

    [SerializeField] private List<SymbolData> list_ThisTimePowerup;
    [SerializeField] private TextMeshProUGUI[] txt_PowerupName;
    [SerializeField] private TextMeshProUGUI[] txt_BaseValue;
    [SerializeField] private Image[] img_PowerUp;
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
        all_CurrentPowerupIndex.Clear();

        for (int i = 0; i < PowerupManager.instance.all_SymbolData.Length; i++) {

            list_ThisTimePowerup.Add(PowerupManager.instance.all_SymbolData[i]);
        }

        for (int i = 0; i < txt_PowerupName.Length; i++) {

            int index = Random.Range(0, list_ThisTimePowerup.Count);
            all_CurrentPowerupIndex.Add(list_ThisTimePowerup[index].GetComponent<SymbolData>().mySymbolIndex);
            txt_PowerupName[i].text = list_ThisTimePowerup[index].transform.name;
            txt_BaseValue[i].text = "BaseValue " + list_ThisTimePowerup[index].Basevalue;

            if (list_ThisTimePowerup[index].spriteRenderer != null) {
                img_PowerUp[i].sprite = list_ThisTimePowerup[index].spriteRenderer.sprite;
            }
            
            list_ThisTimePowerup.RemoveAt(index);

        }

    }

    public void OnClickOnPowerbtnClick(int index) {

      
        int currentIndex = 0;
        for (int i = 0; i < PowerupManager.instance.all_SymbolData.Length; i++) {
            if (all_CurrentPowerupIndex[index] == PowerupManager.instance.all_SymbolData[i].mySymbolIndex) {
                currentIndex = i;
            }
        }
        GridManager.instance.EveryWaveSpawnOneObj(PowerupManager.instance.all_SymbolData[currentIndex].gameObject);
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
