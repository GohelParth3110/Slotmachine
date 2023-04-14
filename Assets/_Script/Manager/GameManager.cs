using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
   
    [SerializeField] private TextMeshProUGUI txt_Score;
    [SerializeField] private TargetSetup target;


    //<symmary> ScoreHandling</summary>
    public int Score;
    private void Awake() {

        instance = this;
    }
    private void Start() {
        Score = 1;
        txt_Score.text = Score.ToString();
        UiManager.instance.GetUiHomeScreen.gameObject.SetActive(true);
    }



    public void UpdateScore(int score) {
        this.Score += score;
        
        txt_Score.text = this.Score.ToString();
        
    }

   public TargetSetup GetTargetofCoin() {
        return target;
   }
   
}
