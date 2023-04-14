using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAnimation : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private TextMesh text_Mesh;
    [SerializeField] private int value;


    // <Summary>
    // In this When SetCoinFunction call At That time Some time Coin go to This Target postion
    // After Goes to Target postion Destroy Gameobject
    // </summary>




    public void SetCoinValue(int Value) {
        text_Mesh.text = Value.ToString();
        this.value = Value;
      
    }
    public void SetAnimation(float CoinAnmationTime, float afterSpawnDelay) {
        StartCoroutine(AfterSpawnDelay(afterSpawnDelay, CoinAnmationTime));
    }

    private IEnumerator AfterSpawnDelay(float afterSpawnDelay, float CoinAnimation) {
        yield return new WaitForSeconds(afterSpawnDelay);

        StartCoroutine(RunforTime(CoinAnimation));
    }

    private IEnumerator RunforTime(float time) {

        
        Vector3 startingPosition = transform.position;
        float currentTime = 0;
        while (currentTime < time) {

        

            transform.position = Vector3.Lerp(startingPosition, GameManager.instance.GetTargetofCoin().transform.position, (currentTime / time));
            currentTime += Time.deltaTime;
            yield return null;
        }
        GameManager.instance.GetTargetofCoin().TargetTextChange(this.value);
        Destroy(gameObject);
    }

    
}
