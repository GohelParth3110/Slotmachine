using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjSetup : MonoBehaviour
{


    public List<System.Action> SetListOfAction(List<System.Action> list_Actions, List<SymbolData> list_Gamobject) {

       // no Passive 

        // PowerUp Synergy
        for (int i = 0; i < list_Gamobject.Count; i++) {

            //bitcoin = 1 , Nospawn Obj
            //CardenoCoin = 2 ,NoSpawnObj
            //EthCoin = 3 ,Nospawn Obj
            //StableCoin =4 , Nospawn Obj
            //Accridita Invester = 5, No Spawn Obj 
            if (list_Gamobject[i].mySymbolIndex == 6) {

                list_Actions.Add(list_Gamobject[i].GetComponent<ASIC>().Instance_SetSpawnObj);

            }
            //Auditor = 7, Nospawn Obj
            // BaghHolder = 8 , Nospawn Obj
            // Bear  = 9 , Nospawn Obj
            // Black Swan  = 10 , Nospawn Obj
            // Bull = 11 , Nospawn Obj
            // CandleStickGreen = 12 , Nosapwn Obj
            // CandleStickRed  = 13 , Nospawn Obj

            else if (list_Gamobject[i].mySymbolIndex == 14) {
                list_Actions.Add(list_Gamobject[i].GetComponent<CloudMining>().Instance_SetSpawnObj);
            }
           
            // Crain = 15 , No Spawn Obj
            //Cross Chain = 16, No Spawn Obj
            else if (list_Gamobject[i].mySymbolIndex == 17) {

                list_Actions.Add(list_Gamobject[i].GetComponent<DeadCat>().Instance_SetSpawnObj);
            }
            // Dealth Cross  = 18 , Nospawn Obj
            //escrew = 19 , No spawn Obj

           //FomoBuy = 20 , No Sapwn Obj
            // fur  = 21 ,No Spawn Obj
            //hodler = 22 , No Spawn Obj
            // Kyc = 23 ,No Spawn Obj
            // Loan = 24 , No Spawn Obj
            // Mychal Saylor = 25 , No Spawn Obj
            // NfT = 26 , No Spawn Obj;

           // SatoshNakamoko = 27 , No Spawn Obj
           //TeleGram Scammer  = 28 , No Spawn Obj
            else if (list_Gamobject[i].mySymbolIndex == 29) {

                list_Actions.Add(list_Gamobject[i].GetComponent<Vitalick>().Instance_SetSpawnObj);

            }

            // Whale = 30 , No Spawn Obj
            // X = 31 , No Spawn Obj


        }

        return list_Actions;
    }
}
