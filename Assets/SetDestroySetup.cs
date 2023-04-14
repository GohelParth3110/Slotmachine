using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDestroySetup : MonoBehaviour
{
    public List<System.Action> SetListOfAction(List<System.Action> list_Actions, List<SymbolData> list_Gamobject) {

        // no Passive 

        // PowerUp Synergy
        for (int i = 0; i < list_Gamobject.Count; i++) {

            //bitcoin = 1 , NoDestroySetup
            //CardenoCoin = 2 ,NoDestroySetUp
            //EthCoin = 3 , NoDestroySetUp
            //StableCoin =4 , NoDestroySetUp
            if (list_Gamobject[i].mySymbolIndex == 5) {

                list_Actions.Add(list_Gamobject[i].GetComponent<AccreditedInvestor>().Instance_SetDestroyeObj);

            }
            // Asic = 6 , NoDestroySetup
            else if (list_Gamobject[i].mySymbolIndex == 7) {

                list_Actions.Add(list_Gamobject[i].GetComponent<Auditor>().Instance_SetDestroyeObj);

            }
            // BaghHolder = 8 , NoDestroySetUp
            // Bear  = 9 , NoDestroySetUp
            // Black Swan  = 10 , NoDestroySetUp
            // Bull = 11 , NoDestroySetUp
            // CandleStickGreen = 12 , NoDestroySetUp
            // CandleStickRed  = 13 , NoDestroySetUp

            else if (list_Gamobject[i].mySymbolIndex == 14) {
                list_Actions.Add(list_Gamobject[i].GetComponent<CloudMining>().Instance_SetDestroyeObj);
            }

            // Crain = 15 ,NoDestroySetUp
            //Cross Chain = 16, NoDestroySetUp
            // Dead Cat = 17 , NoDestrySetUp
            // Dealth Cross  = 18 , NoDestrySetUp
            else if (list_Gamobject[i].mySymbolIndex == 14) {
                list_Actions.Add(list_Gamobject[i].GetComponent<Escrow>().Instance_SetDestroyeObj);
            }

            //FomoBuy = 20 ,NoDestrySetUp
            // fur  = 21 ,NoDestrySetUp
            //hodler = 22 , NoDestrySetUp
            // Kyc = 23 ,NoDestrySetUp
            // Loan = 24 , NoDestrySetUp
            else if (list_Gamobject[i].mySymbolIndex == 25) {
                list_Actions.Add(list_Gamobject[i].GetComponent<MichaelSaylor>().Instance_SetDestroyeObj);
            }
            // NfT = 26 , No Spawn Obj;

            else if (list_Gamobject[i].mySymbolIndex == 27) {
                list_Actions.Add(list_Gamobject[i].GetComponent<SatoshiNakamoto>().Instance_SetDestroyeObj);
            }
            else if (list_Gamobject[i].mySymbolIndex == 28) {
                list_Actions.Add(list_Gamobject[i].GetComponent<TelegramScammer>().Instance_SetDestroyeObj);
            }

            //Vitalik = 29 ,NoDestroyObj

            else if (list_Gamobject[i].mySymbolIndex == 30) {
                list_Actions.Add(list_Gamobject[i].GetComponent<Whale>().Instance_SetDestroyeObj);
            }
            else if (list_Gamobject[i].mySymbolIndex == 31) {
                list_Actions.Add(list_Gamobject[i].GetComponent<Xpowerup>().Instance_SetDestroyeObj);
            }


        }

        return list_Actions;
    }
}
