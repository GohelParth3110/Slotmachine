using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public static PowerupManager instance;

    public SymbolData[] all_SymbolData;

    public GameObject[] all_Coin;

    public GameObject[] all_Passive;
    
    public List<AirDrop> airDrop;
    
    public List<DexHandling> dexHandling;
    public List<GameObject> list_ActivePessiveInHirechy;

    private void Awake() {

        instance = this;
    }

    public  List<GameObject> ShortingPassive() {

        for (int i = 0; i < list_ActivePessiveInHirechy.Count; i++) {
            for (int j = i + 1; j < list_ActivePessiveInHirechy.Count; j++) {

                if (list_ActivePessiveInHirechy[i].GetComponent<IndexOfPassive>().myIndex >
                        list_ActivePessiveInHirechy[j].GetComponent<IndexOfPassive>().myIndex) {

                    GameObject swap;

                    swap = list_ActivePessiveInHirechy[j];

                    list_ActivePessiveInHirechy[j] = list_ActivePessiveInHirechy[i];

                    list_ActivePessiveInHirechy[i] = swap;

                }

            }
        }
        return list_ActivePessiveInHirechy;
    }

   

   
}
