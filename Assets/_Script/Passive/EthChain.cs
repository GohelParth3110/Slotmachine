using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EthChain : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private float flt_StopAnimationTime;
    [SerializeField] private float yOffset;

    private int cardanoCoinIndex = 2;
    private int ethCoinSymboleIndex = 3;


    public void Instance_SetSynergy() {

        for (int i = 0; i < GridManager.instance.list_ActivateInHirachy.Count; i++) {

            if (ethCoinSymboleIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                ETHCoin ethCoin = GridManager.instance.list_ActivateInHirachy[i].GetComponent<ETHCoin>();
                ethCoin.BaseValue += 1;
                StopAnimation();
                GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();

            }
            else if (cardanoCoinIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {
                CardanoCoin cardanoCoin = GridManager.instance.list_ActivateInHirachy[i].GetComponent<CardanoCoin>();
                cardanoCoin.BaseValue += 1;
                StopAnimation();
                GridManager.instance.list_ActivateInHirachy[i].GetComponentInParent<RawMotion>().VFXForMOtion();
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
