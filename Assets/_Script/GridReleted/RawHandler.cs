using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawHandler : MonoBehaviour
{
    [SerializeField] private RawMotion[] all_RawMotions;
    [SerializeField] private bool[] all_Ismove;
    public bool isChecking;

    //<summary>
    //when GridManager Set All data And Spin Btn Click At that Time SlotMachine Start
    //after Start Slotmachine We Get Data From  All raw Motion Script 
    // If All Rawmotion Is Move Bool False Then Get date From Gridmanager And Goes To Next Procedure
    //</summary>
    public void SetAllRawMotion() {
        isChecking = true;
        for (int i = 0; i < all_RawMotions.Length; i++) {

            all_RawMotions[i].SetRotate();
        }
    }

    private void Update() {

        if (!isChecking) {
            return;
        }

        for (int i = 0; i < all_RawMotions.Length; i++) {
            if (all_RawMotions[i].Ismove) {
                return;
            }
        }

        isChecking = false;
        GridManager.instance.SetPowerupProcess();

    }
}
