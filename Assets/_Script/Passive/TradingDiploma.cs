using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradingDiploma : MonoBehaviour
{
    private int bitcoinSymboleIndex = 1;
    private int cardanoCoinIndex = 2;
    private int ethCoinSymboleIndex = 3;
    private int stableCoinIndex = 4;
    [SerializeField] private int percentageOfWorthIncrease;
    [SerializeField] private int percentageOfWorthDecrease;

    [SerializeField] private int cuurntIndex;
    [SerializeField] private int changeIndex;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private float flt_StopAnimationTime;
    [SerializeField] private float yOffset;

    private void OnEnable() {

        GridManager.instance.SetPassive += Instance_SetPassive;
    }

    private void OnDisable() {

        GridManager.instance.SetPassive -= Instance_SetPassive;
    }

    private void Instance_SetPassive(object sender, System.EventArgs e) {

        cuurntIndex++;

        if (cuurntIndex >= changeIndex) {

            cuurntIndex = 0;
            int index = Random.Range(0, 100);

            if (index < percentageOfWorthDecrease) {
                Debug.Log("ReduceCoinValue");

                SetCoinValue(-1);
            }
            else if (index < percentageOfWorthIncrease + percentageOfWorthDecrease) {
                Debug.Log("IncreasingCoinValue");

                SetCoinValue(1);
            }
        }

    }

    private void SetCoinValue(int value) {
        for (int i = 0; i < GridManager.instance.list_ActivateInHirachy.Count; i++) {


            if (bitcoinSymboleIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                BitCoin bitCoin = GridManager.instance.list_ActivateInHirachy[i].GetComponent<BitCoin>();
                bitCoin.BaseValue += value;
                bitCoin.GetComponentInParent<RawMotion>().VFXForMOtion();
                StopAnimation();
            }
            else if (cardanoCoinIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                CardanoCoin CaradanoCoin = GridManager.instance.list_ActivateInHirachy[i].GetComponent<CardanoCoin>();

                CaradanoCoin.BaseValue += value;
                CaradanoCoin.GetComponentInParent<RawMotion>().VFXForMOtion();
                StopAnimation();

            }
            else if (ethCoinSymboleIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                ETHCoin eTHCoin = GridManager.instance.list_ActivateInHirachy[i].GetComponent<ETHCoin>();

                eTHCoin.BaseValue += value;
                eTHCoin.GetComponentInParent<RawMotion>().VFXForMOtion();
                StopAnimation();

            }
            else if (stableCoinIndex == GridManager.instance.list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex) {

                StableCoin stableCoin = GridManager.instance.list_ActivateInHirachy[i].GetComponent<StableCoin>();
                stableCoin.BaseValue += value;
                stableCoin.GetComponentInParent<RawMotion>().VFXForMOtion();
                StopAnimation();
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
