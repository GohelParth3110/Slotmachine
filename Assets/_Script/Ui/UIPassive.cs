using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;

public class UIPassive : MonoBehaviour
{
    [SerializeField] private GameObject Content;
    [SerializeField]private List<GameObject> all_PassiveThisWave;
    [SerializeField] private List<GameObject> list_ActiveInScreen;
    [SerializeField] private TextMeshProUGUI[] all_TxtPassive;
    [SerializeField] private Button btn_SkipBtn;
    [SerializeField] private Button btn_ReloadBtn;
    [SerializeField] private int currentReloadValue;
    [SerializeField]private int reloadValue;
    [SerializeField]private TextMeshProUGUI txt_NextReloadValue;
    [SerializeField] private TextMeshProUGUI txt_RemaingValue;
    [SerializeField] private TextMeshProUGUI txt_CurrentSpin;
    [SerializeField]private TextMeshProUGUI txt_CurrentLevelCollectedCoin;
    [SerializeField]private TextMeshProUGUI txt_RentCoin;

    private void Awake() {

        btn_SkipBtn.onClick.AddListener(OnClickOnSkipBtnClick);
        btn_ReloadBtn.onClick.AddListener(OnClickOnReloadBtnClick);
    }

   

    private void OnEnable() {

        SetPowerupPanel();
        currentReloadValue = reloadValue;
        txt_NextReloadValue.text = currentReloadValue.ToString();
        txt_CurrentLevelCollectedCoin.text = GameManager.instance.Score.ToString();
        txt_RentCoin.text = LevelManager.instance.CurrentLevel.RentValue.ToString();
        txt_CurrentSpin.text = LevelManager.instance.CurrentSpin.ToString();
        txt_RemaingValue.text = (LevelManager.instance.CurrentLevel.SpinValue - LevelManager.instance.CurrentSpin).ToString();
    }

    private void SetPowerupPanel() {

        all_PassiveThisWave.Clear();

        for (int i = 0; i < PowerupManager.instance.all_Passive.Length; i++) {

            all_PassiveThisWave.Add(PowerupManager.instance.all_Passive[i]);

        }

        list_ActiveInScreen.Clear();
        for (int i = 0; i < all_TxtPassive.Length; i++) {

          int  Index = Random.Range(0, all_PassiveThisWave.Count);

            all_TxtPassive[i].text = all_PassiveThisWave[Index].transform.name;
            list_ActiveInScreen.Add(all_PassiveThisWave[Index]);
            all_PassiveThisWave.RemoveAt(Index);

        }
    }
    public void OnClickOnPassiveBtnClick(int index) {

       GameObject current =  Instantiate(list_ActiveInScreen[index], transform.position, transform.rotation, Content.transform);

        PowerupManager.instance.list_ActivePessiveInHirechy.Add(current);
        if (current.TryGetComponent<DexHandling>(out DexHandling dex)) {

            PowerupManager.instance.dexHandling.Add(dex);
        }
        else if (current.TryGetComponent<AirDrop>(out AirDrop airDrop)) {
            PowerupManager.instance.airDrop.Add(airDrop);
        }
        this.gameObject.SetActive(false);
        UiManager.instance.GetUiGamePlayScreen.gameObject.SetActive(true);
        UiManager.instance.GetUiGamePlayScreen.btn_Spin.gameObject.SetActive(true);
        for (int i = 0; i < GridManager.instance.list_ActivateInHirachy.Count; i++) {
            if (GridManager.instance.list_ActivateInHirachy[i].TryGetComponent<CrossChain>(out CrossChain crossChain)) {
                crossChain.IsSwap = true;
            }
        }

    }
    private void OnClickOnReloadBtnClick() {

        if (GameManager.instance.Score < currentReloadValue + 1) {
            return;
        }

       
        GameManager.instance.UpdateScore(-currentReloadValue);
        txt_CurrentLevelCollectedCoin.text = GameManager.instance.Score.ToString();
        currentReloadValue += reloadValue;
        txt_NextReloadValue.text = currentReloadValue.ToString();
        SetPowerupPanel();
    }

    private void OnClickOnSkipBtnClick() {
        this.gameObject.SetActive(false);
        UiManager.instance.GetUiGamePlayScreen.gameObject.SetActive(true);
        UiManager.instance.GetUiGamePlayScreen.btn_Spin.gameObject.SetActive(true);
        GridManager.instance.SkipTimeObjectSetup();
        for (int i = 0; i < GridManager.instance.list_ActivateInHirachy.Count; i++) {
            if (GridManager.instance.list_ActivateInHirachy[i].TryGetComponent<CrossChain>(out CrossChain crossChain)) {
                crossChain.IsSwap = true;
                Debug.Log(crossChain.IsSwap);
            }
        }
    }

}
