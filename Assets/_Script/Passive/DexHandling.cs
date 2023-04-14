using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DexHandling : MonoBehaviour {

    [SerializeField] private int currentSpin;
    [SerializeField] private int maxSpin;
    [SerializeField] private  bool isSwap;
    [SerializeField] private bool isproces;
    
   
    [SerializeField] private int currentSwap;
    [SerializeField] private int maxSwap;
    [SerializeField]private RectTransform rectTransform;
    [SerializeField]private float yOffset;
    [SerializeField]private float flt_StopAnimationTime;

    private void OnEnable() {

        GridManager.instance.SetPassive += Instance_SetPassive;
    }
    private void OnDisable() {
        GridManager.instance.SetPassive -= Instance_SetPassive;
    }

    private void Instance_SetPassive(object sender, EventArgs e) {

        isSwap = false;
       
        currentSpin++;
        if (currentSpin>= maxSpin) {
            currentSpin = 0;
            isSwap = true;
            currentSwap = 0;
            StopAnimation();
        }
    }

    public void SetSwapProcess() {
        if (!isSwap) {
            return;
        }

        isproces = true;
    }

    private void Update() {

        


        if (Input.GetMouseButton(0) && isproces && isSwap) {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray,out hit)) {

                if (hit.collider != null) {

                    currentSwap++;
                    if (currentSwap>=maxSwap) {
                        
                        currentSwap = 0;
                        isSwap = false;
                        currentSpin = 0;
                    }
                    isproces = false;
                    GridManager.instance.RemoveGameObjectInList(hit.collider.gameObject);
                    StartCoroutine(UiPowerupActive());
                }
            }
        }
    }

    private IEnumerator UiPowerupActive() {
        yield return new WaitForSeconds(0.5f);
        UiManager.instance.GetUiPowerupScreen.gameObject.SetActive(true);
    }
    private void StopAnimation() {

        Sequence SEQ = DOTween.Sequence();

        float startPostion = rectTransform.localPosition.y;
        SEQ.Append(rectTransform.DOLocalMoveY(startPostion - yOffset, flt_StopAnimationTime)).SetEase(Ease.Linear).
           Append(rectTransform.DOLocalMoveY(startPostion + yOffset, flt_StopAnimationTime).SetLoops(3, LoopType.Yoyo)).SetEase(Ease.Linear)
           .Append(rectTransform.DOLocalMoveY(startPostion, flt_StopAnimationTime).SetEase(Ease.Linear));


    }
}
