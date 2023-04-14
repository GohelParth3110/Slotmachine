using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antidumb : MonoBehaviour
{
    private int bitcoinSymboleIndex = 1;
    private int cardanoCoinIndex = 2;
    private int ethCoinSymboleIndex = 3;
    private int stableCoinIndex = 4;
    [SerializeField]private float yOffset;
   [SerializeField]private float flt_StopAnimationTime;
   [SerializeField] private RectTransform rectTransform;

    private void OnEnable() {

        GridManager.instance.setAntiDumb += Instance_setAntiDumb;
    }

  

    private void OnDisable() {
        GridManager.instance.setAntiDumb -= Instance_setAntiDumb;
    }

    private void Instance_setAntiDumb(object sender, System.EventArgs e) {
        for (int i = 0; i < GridManager.instance.list_ActivateInHirachy.Count; i++) {

          

                if (bitcoinSymboleIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                    BitCoin bitCoin = GridManager.instance.list_ActivateInHirachy[i].GetComponent<BitCoin>();
                    if (bitCoin.BaseValue<1) {
                        bitCoin.BaseValue = 1;
                        bitCoin.GetComponentInParent<RawMotion>().VFXForMOtion();
                        StopAnimation();
                    }
                    
                }
                else if (cardanoCoinIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                CardanoCoin CaradnoCoin = GridManager.instance.list_ActivateInHirachy[i].GetComponent<CardanoCoin>();

                if (CaradnoCoin.BaseValue < 1) {
                    CaradnoCoin.BaseValue = 1;
                    CaradnoCoin.GetComponentInParent<RawMotion>().VFXForMOtion();
                    StopAnimation();
                }

                }
                else if (ethCoinSymboleIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                    ETHCoin eTHCoin = GridManager.instance.list_ActivateInHirachy[i].GetComponent<ETHCoin>();

                    if (eTHCoin.BaseValue <1) {
                        eTHCoin.BaseValue = 1;
                        eTHCoin.GetComponentInParent<RawMotion>().VFXForMOtion();
                        StopAnimation();
                    }

                }
                else if (stableCoinIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                    StableCoin stableCoin = GridManager.instance.list_ActivateInHirachy[i].GetComponent<StableCoin>();
                    if (stableCoin.BaseValue <1) {
                        stableCoin.BaseValue = 1;
                        stableCoin.GetComponentInParent<RawMotion>().VFXForMOtion();
                        StopAnimation();
                    }
                }
            

        }
    }
     private void StopAnimation() {

        Sequence SEQ = DOTween.Sequence();

        float startPostion = rectTransform.localPosition.y;
        SEQ.Append(rectTransform.DOLocalMoveY(startPostion - yOffset, flt_StopAnimationTime)).SetEase(Ease.Linear).
           Append(rectTransform.DOLocalMoveY(startPostion + yOffset, flt_StopAnimationTime).SetLoops(3, LoopType.Yoyo)).SetEase(Ease.Linear)
           .Append(rectTransform.DOLocalMoveY(startPostion, flt_StopAnimationTime).SetEase(Ease.Linear));
          

    }
}

