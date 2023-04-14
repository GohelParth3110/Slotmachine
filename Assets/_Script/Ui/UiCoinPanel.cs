using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class UiCoinPanel : MonoBehaviour
{
    [SerializeField] private SymbolData[] all_Coin;
    [SerializeField]private List<SymbolData> list_Symboledata;
    [SerializeField] private TextMeshProUGUI[] all_Txt_Header;
    [SerializeField] private TextMeshProUGUI[] all_Txt_Value;
    [SerializeField] private Image[] all_Img;
    [SerializeField] private Button btn_Skip;
    private GameObject clickObject;
    private GameObject CrossChain;



    private void Awake() {
        btn_Skip.onClick.AddListener(OnClickonSkipBtn_Click);
    }

    private void OnClickonSkipBtn_Click() {
        this.gameObject.SetActive(false);
        UiManager.instance.GetUiGamePlayScreen.gameObject.SetActive(true);
        UiManager.instance.GetUiGamePlayScreen.btn_Spin.gameObject.SetActive(true);
       
    }

    public void SetUiPanel(GameObject Coin , GameObject crossChain) {

       
        list_Symboledata.Clear();

        for (int i = 0; i < all_Coin.Length; i++) {
            if (all_Coin[i].mySymbolIndex != Coin.GetComponent<SymbolData>().mySymbolIndex) {
                list_Symboledata.Add(all_Coin[i]);
            }
        }
        for (int i = 0; i < list_Symboledata.Count; i++) {

            all_Txt_Header[i].text = list_Symboledata[i].gameObject.name;
            all_Txt_Value[i].text = list_Symboledata[i].Basevalue.ToString();
            if (list_Symboledata[i].spriteRenderer != null) {
                all_Img[i].sprite = list_Symboledata[i].spriteRenderer.sprite;
            }

        }
        clickObject = Coin;
        this.CrossChain = crossChain;
       
    }

    public void OnClickOnPowerbtnClick(int index) {


        GridManager.instance.RemoveGameObjectInList(clickObject);
        GridManager.instance.RemoveGameObjectInList(CrossChain);
        GridManager.instance.EveryWaveSpawnOneObj(list_Symboledata[index].gameObject);
       
        this.gameObject.SetActive(false);
        UiManager.instance.GetUiGamePlayScreen.gameObject.SetActive(true);
        UiManager.instance.GetUiGamePlayScreen.btn_Spin.gameObject.SetActive(true);
        
    }
}
