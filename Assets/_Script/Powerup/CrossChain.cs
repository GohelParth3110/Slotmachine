using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossChain : MonoBehaviour
{
    public bool IsSwap;
    private string tag_Coin = "Coin";

    private void OnEnable() {
        IsSwap = false;
    }
    private void Update() {

        if (Input.GetMouseButton(0) && IsSwap) {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {

                if (hit.collider.CompareTag(tag_Coin)) {
                  
                    StartCoroutine(UICoinPanel(hit.collider.gameObject));
                }
            }
        }
    }

    private IEnumerator UICoinPanel(GameObject Coin ) {
      
        yield return new WaitForSeconds(0.5f);
        UiManager.instance.GetUiCoinPanelScreen.gameObject.SetActive(true);
        
        UiManager.instance.GetUiCoinPanelScreen.SetUiPanel(Coin,this.gameObject);
    }
}
