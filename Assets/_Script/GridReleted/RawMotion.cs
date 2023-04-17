using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class RawMotion : MonoBehaviour
{
    public bool Ismove;
    public bool isTurnZero;
    [SerializeField] private float startPostion;
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private float changePostion;
    [SerializeField] private float afterChangeAssignPostion;
    [SerializeField] private int turn;
    [SerializeField] private int maxTurn;
    [SerializeField] private float flt_StopAnimationTime;
   


    //<Summary>
    //in this Script First Get Data From Raw Handler Start Roating SlotMachine Product
    // after Start Slot Machine Script Count Turn also
    // Main Imaportant this All rawmotion Have Same Offset
    // When Turn Get MaxTurn Some Stop Animation
    // This Stop Animation Also  Call Synerygy Of All Powerup Product
    //</Summary>
    

    public void SetRotate() {

        Ismove = true;
        Sequence SEQ = DOTween.Sequence();
        startPostion = transform.position.y;

        StartAnimation();

    }

    private void StartAnimation() {
       
        
        float postion = startPostion - 2;
        transform.DOMoveY(postion, moveSpeed).SetEase(Ease.Linear).OnComplete(ResetBackground);
    }

    public void VFXForMOtion() {
        
        Sequence SEQ = DOTween.Sequence();

        SEQ.Append(transform.DOLocalMoveY(startPostion - 0.2f, flt_StopAnimationTime)).SetEase(Ease.Linear).
           Append(transform.DOLocalMoveY(startPostion + 0.2f, flt_StopAnimationTime).SetLoops(3, LoopType.Yoyo)).SetEase(Ease.Linear)
           .Append(transform.DOLocalMoveY(startPostion, flt_StopAnimationTime).SetEase(Ease.Linear)).
           AppendInterval(flt_StopAnimationTime).AppendCallback(StopCallBack);

    }
    private void StopSlotmachine() {
        Sequence SEQ = DOTween.Sequence();

        SEQ.Append(transform.DOLocalMoveY(startPostion - 0.4f, 0.2f)).SetEase(Ease.Linear)
            .Append(transform.DOLocalMoveY(startPostion, 0.5f).SetEase(Ease.Linear)).
            AppendInterval(flt_StopAnimationTime).AppendCallback(StopCallBack);
    }
   
    private void StopCallBack() {

        
        Ismove = false;
        isTurnZero = false;
    }

    void ResetBackground() {

        if (!Ismove) {

            return;
        }



        if (isTurnZero) {

          

            if (transform.position.y - startPostion < 2) {

                Sequence SEQ = DOTween.Sequence();

                SEQ.Append(transform.DOMoveY(startPostion, moveSpeed).SetEase(Ease.Linear)).OnComplete(StopSlotmachine);



                return;
            }
            float pos = transform.position.y - 2;

            transform.DOMoveY(pos, moveSpeed).SetEase(Ease.Linear).OnComplete(ResetBackground);

        }
        else {

            // Reset the background position to the start and start the animation again
            if (transform.position.y < changePostion && !isTurnZero) {

                transform.position = new Vector3(transform.position.x, afterChangeAssignPostion, transform.localPosition.z);
                turn++;
                if (turn > maxTurn) {

                    turn = 0;
                    isTurnZero = true;

                }

            }

            float postion = transform.position.y - 2;

            transform.DOMoveY(postion, moveSpeed).SetEase(Ease.Linear).OnComplete(ResetBackground);

        }






    }






}
