using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TargetSetup : MonoBehaviour
{
    [SerializeField] private TextMesh txt_Mesh;
    private int Coin;
    
    //<Summary>
    //In this Script Set up All Coin Animation
    // Target Up Animation
    // Taget DownAnimation
    // TextOf Coin
    // reset Coin
    //</Summary>

    private void Start() {

        txt_Mesh.gameObject.SetActive(false);
    }
    public void TargetUpAnimation(float time) {

        transform.DOMoveY(2.2f, time);
        

    }
    public void TargetDownAmiantion(float time) {

        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOMoveY(0.5f, time)).AppendInterval(time).AppendCallback(CheckingGameOver);
       
        
    }
    private void CheckingGameOver() {
        if (GameManager.instance.Score < 0) {
            UiManager.instance.GetUiGamePlayScreen.gameObject.SetActive(false);
            UiManager.instance.GetGameoverScreen.gameObject.SetActive(true);
        }
    }
    public void TargetTextChange( int Value) {

        Coin += Value;
        txt_Mesh.text = Coin.ToString();
        txt_Mesh.gameObject.SetActive(true);

    }

    // if Spin Chnage ValueChange
    public void resetCoin() {
        LevelManager.instance.UpdateCurrentLevelCoin(Coin);
        Coin = 0;
        txt_Mesh.text = Coin.ToString();
        txt_Mesh.gameObject.SetActive(false);
    }
}
