using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AirDrop : MonoBehaviour
{
   

    [SerializeField] private int cuurntIndex;
    [SerializeField] private int SpawnCoinIndex;
    [SerializeField] private RectTransform rectTransform;

    private bool isSpawn;
    [SerializeField]private float flt_StopAnimationTime;
    [SerializeField]private float yOffset;

    private void OnEnable() {
        isSpawn = false;
        GridManager.instance.SetPassive += Instance_SetPassive;
    }

    private void OnDisable() {

        GridManager.instance.SetPassive -= Instance_SetPassive;
    }

    private void Instance_SetPassive(object sender, System.EventArgs e) {

       
        cuurntIndex++;
        if (cuurntIndex>=SpawnCoinIndex) {
            cuurntIndex = 0;
            isSpawn = true;
            Spawn();

        }
    }
    public void Spawn() {

        if (!isSpawn) {
            return;
        }
      
        int index = Random.Range(0, PowerupManager.instance.all_Coin.Length);
        StopAnimation();
        GridManager.instance.EveryWaveSpawnOneObj(PowerupManager.instance.all_Coin[index]);
        isSpawn = false;
    }

    private void StopAnimation() {

        Sequence SEQ = DOTween.Sequence();

        float startPostion = rectTransform.localPosition.y;
        SEQ.Append(rectTransform.DOLocalMoveY(startPostion - yOffset, flt_StopAnimationTime)).SetEase(Ease.Linear).
           Append(rectTransform.DOLocalMoveY(startPostion + yOffset, flt_StopAnimationTime).SetLoops(3, LoopType.Yoyo)).SetEase(Ease.Linear)
           .Append(rectTransform.DOLocalMoveY(startPostion, flt_StopAnimationTime).SetEase(Ease.Linear));


    }
}
