using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ProofofStake : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private float flt_StopAnimationTime;
    [SerializeField] private float yOffset;
    [SerializeField] private int baseValue;
   
   

    // The canvas position that you want to convert to world position
   // public Vector2 canvasPosition;

    private int ethCoinSymboleIndex = 3;


  
    public Vector2 canvasPosition;

  


    private void OnEnable() {
        GridManager.instance.SetCoinSetup += Instance_SetCoinSetup;
   
    }



    private void Update() {
      
    }

    private void OnDisable() {
        GridManager.instance.SetCoinSetup -= Instance_SetCoinSetup;
    }



    public void Instance_SetSynergy() {
        baseValue = 0;
        for (int i = 0; i < GridManager.instance.list_ActivateInHirachy.Count; i++) {

            if (ethCoinSymboleIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

               
                baseValue += 1;
                StopAnimation();
                GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();

            }

        }
    }

    private void Instance_SetCoinSetup(object sender, System.EventArgs e) {

   
        CoinHandler.instance.SpawnCoin(baseValue, transform.position);

    }

    private void StopAnimation() {

        Sequence SEQ = DOTween.Sequence();

        float startPostion = rectTransform.localPosition.y;
        SEQ.Append(rectTransform.DOLocalMoveY(startPostion - yOffset, flt_StopAnimationTime)).SetEase(Ease.Linear).
           Append(rectTransform.DOLocalMoveY(startPostion + yOffset, flt_StopAnimationTime).SetLoops(3, LoopType.Yoyo)).SetEase(Ease.Linear)
           .Append(rectTransform.DOLocalMoveY(startPostion, flt_StopAnimationTime).SetEase(Ease.Linear));


    }

   
}
