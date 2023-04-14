using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;


public class GridManager : MonoBehaviour
{
    public delegate void EventHandler(object sender, EventArgs e);
    public event EventHandler SetPassive;
    public event EventHandler setAntiDumb;
    public event EventHandler SetSpawnObj;
    public event EventHandler SetCoinSetup;
    public event EventHandler SetDestroyeObj;
    public static GridManager instance;
    public SynergySetup synergySetup;
   // [SerializeField] private GameObject[] all_Item;
    [SerializeField] private  Transform[] all_Postion;
    [SerializeField] private GameObject[] all_GameStartObj;
    [SerializeField] private List<GameObject> list_OfActivateGameObject;
    [SerializeField] private List<GameObject> list_ThisWaveObject;
    public List<GameObject> list_ActivateInHirachy;
    List<Action> functions = new List<Action>();
    [SerializeField] List<SymbolData> list_Symboldat = new List<SymbolData>();
    [SerializeField] private List<GameObject> list_Shorting;
    [SerializeField]private List<Transform> list_AllPostion;
    [SerializeField] private GameObject transform_Store;
    [SerializeField] private GameObject ethCoin;
    [SerializeField] private GameObject bitcoin;
    [SerializeField] private GameObject fur;
    [SerializeField] private RawHandler RawHandler;
    [SerializeField] private float flt_DelayStartEvent;
    [SerializeField] private float flt_DealayOfSpawnObj;
    [SerializeField] private float flt_DelayOfDeStroyObj;
    [SerializeField] private float flt_DelayOfSynergyEvent;
    [SerializeField] private float flt_DealyAntiDumb;
    [SerializeField] private float flt_DelayOfCoinSpwn;
    [SerializeField] private float flt_DealyOfCoinAnimation;
    public bool isLoanActivated;
    public bool isCrossChainActiveted;
    private string tag_CrossChain = "CrossChain";


    // <Summary> This Script Controll All Game Logic
    // Startting If Game All Requrirement Obj Spwn  and Add In one List
    // After All Grid Postion Make In list
    // then get Postion Of Obj
    // </Summary>
    private void Awake() {

        instance = this;
        
    }
    private void Start() {
       
            for (int i = 0; i < all_GameStartObj.Length; i++) {

                GameObject current = Instantiate(all_GameStartObj[i], transform.position, transform.rotation, transform_Store.transform);
                current.SetActive(false);
                list_OfActivateGameObject.Add(current); 
                list_ActivateInHirachy.Add(current);

            }
           

        // Get All grid In List
        for (int i = 0; i < all_Postion.Length; i++) {
            list_AllPostion.Add(all_Postion[i]);
           
        }

        for (int i = 0; i < list_ActivateInHirachy.Count; i++) {
            int index = Random.Range(0, list_AllPostion.Count);

            if (list_AllPostion[index].childCount != 0) {

                Transform child = list_AllPostion[index].GetChild(0);

                child.SetParent(transform_Store.transform);
                child.gameObject.SetActive(false);
            }

            list_ActivateInHirachy[i].transform.SetParent(list_AllPostion[index]);
            list_ActivateInHirachy[i].transform.localPosition = Vector3.zero;
            list_ActivateInHirachy[i].SetActive(true);
            list_AllPostion.RemoveAt(index);
        }

        // Remove All list In grid
        list_AllPostion.Clear();


    }


    //<Summary> First Decrease Score
    // Set Rendom Postion Of Hirachy Obj
    //Then Slot Machine Learn
    // After Run SlotMachine of Delay Animation Learn
    // Then Event Learn
    //</Summary>



    public void SpinClick() {

      
        GameManager.instance.UpdateScore(-1);

      

        // powerup > Our Grid setRenadom power

        if (list_OfActivateGameObject.Count > all_Postion.Length) {

          
            list_ActivateInHirachy.Clear();
            for (int i = 0; i < all_Postion.Length; i++) {

                int index = Random.Range(0, list_ThisWaveObject.Count);
                list_ActivateInHirachy.Add(list_ThisWaveObject[index]);
                list_ThisWaveObject.RemoveAt(index);
            }


        }
       

        // Get All grid In List
        for (int i = 0; i < all_Postion.Length; i++) {
            list_AllPostion.Add(all_Postion[i]);
           // all_Postion[i].GetComponent<GridSymbolData>().currentSymbolIndex = 0;


        }

      
        for (int i = 0; i < list_ActivateInHirachy.Count; i++) {
           
            isCrossChainActiveted = false;
          
            if (list_ActivateInHirachy[i].CompareTag(tag_CrossChain)) {
                isCrossChainActiveted = true;
                list_ActivateInHirachy[i].GetComponent<CrossChain>().IsSwap = false;
            }
            int index = Random.Range(0, list_AllPostion.Count);

            if (list_AllPostion[index].childCount != 0) {

                Transform child = list_AllPostion[index].GetChild(0);

                child.SetParent(transform_Store.transform);
                child.gameObject.SetActive(false);
            }

            list_ActivateInHirachy[i].transform.SetParent(list_AllPostion[index]);
            list_ActivateInHirachy[i].transform.localPosition = Vector3.zero;
            list_ActivateInHirachy[i].SetActive(true);

           // list_AllPostion[index].GetComponent<GridSymbolData>().currentSymbolIndex = list_ActivateInHirachy[i].GetComponent<SymbolData>().mySymbolIndex;

            list_AllPostion.RemoveAt(index);
        }


       

        // Remove All list In grid
        list_AllPostion.Clear();


        ShortingData(list_ActivateInHirachy);
       
      
   
    }

    private void ShortingData(List<GameObject> gameObjects) {

        for (int i = 0; i < gameObjects.Count; i++) {
            for (int j = i + 1; j < gameObjects.Count; j++) {

                if (gameObjects[i].GetComponent<SymbolData>().mySymbolIndex >
                        gameObjects[j].GetComponent<SymbolData>().mySymbolIndex) {

                    GameObject swap;

                    swap = gameObjects[j];

                    gameObjects[j] = gameObjects[i];

                    gameObjects[i] = swap;

                }

            }
        }


        list_Symboldat.Clear();
        for (int i = 0; i < gameObjects.Count; i++) {
            list_Symboldat.Add(gameObjects[i].GetComponent<SymbolData>());
           
        }
        functions.Clear();
        functions = synergySetup.SetListOfAction(functions, list_Symboldat);
        RawHandler.SetAllRawMotion();
    }

     public void SetPowerupProcess() {

        StartCoroutine(DelayOfPowerupProcess());
        // process Powerup

     }

    private IEnumerator DelayOfPowerupProcess() {

        yield return new WaitForSeconds(flt_DelayStartEvent);
        float time = 0;
        if (SetPassive != null) {
            SetPassive.Invoke(this, EventArgs.Empty);
            time = flt_DealayOfSpawnObj;
        }
        else {
            time = 0;
        }
       
        StartCoroutine(DealayOfSpawnObjEvent(time));
      
        
       
    }

    private IEnumerator DealayOfSpawnObjEvent(float delayOfSpawnObj) {
        yield return new WaitForSeconds(delayOfSpawnObj);
        float time = 0;
        if (SetSpawnObj != null) {
            SetSpawnObj.Invoke(this, EventArgs.Empty);
            time = flt_DealayOfSpawnObj;
        }
        else {
            time = 0;
        }
        StartCoroutine(DelayOfDestroyEvent(time));
    }

    private IEnumerator DelayOfDestroyEvent(float time) {
        yield return new WaitForSeconds(time);
        float Time;
        if (SetDestroyeObj !=null) {
            SetDestroyeObj.Invoke(this, EventArgs.Empty);
            Time = flt_DelayOfSynergyEvent;
        }
        else {
            Time = 0;
        }
        StartCoroutine(DelayOfSynerGy(Time));
       
    }

    private IEnumerator DelayOfSynerGy(float  time ) {
        yield return new WaitForSeconds(time);
        float Time;

       

        if (functions.Count != 0) {
           
            Time = flt_DelayOfSynergyEvent;
            for (int i = 0; i < functions.Count; i++) {
                functions[i]();
            }
            
        }
        else {
            Time = 0;
        }
       
       
        StartCoroutine(DealayOfAnitidumb(Time));
       
       
    }

    private IEnumerator DealayOfAnitidumb(float time) {
        yield return new WaitForSeconds(time);
        float Time;
        if (setAntiDumb != null) {
            setAntiDumb.Invoke(this, EventArgs.Empty);
            Time = flt_DelayOfCoinSpwn;
        }
        else {
            Time = 0;
        }
        StartCoroutine(DelayCoinSpawn(Time));
    }
       

    private IEnumerator DelayCoinSpawn(float time) {

        yield return new WaitForSeconds(time);
        SetCoinSetup?.Invoke(this, EventArgs.Empty);
        StartCoroutine(StartCoinAnimationDelay());
       
    }

    private IEnumerator StartCoinAnimationDelay() {
      
        yield return new WaitForSeconds(flt_DealyOfCoinAnimation);
        CoinHandler.instance.CoinAnimation();
        StartCoroutine(EndofCoinProcedure());
    }

    private IEnumerator EndofCoinProcedure() {
        yield return new WaitForSeconds(CoinHandler.instance.TotalTimeGetEvent());
      
        LevelManager.instance.IncresingSpin();
    }

    public void SkipTimeObjectSetup() {
        list_ThisWaveObject.Clear();

        for (int i = 0; i < list_OfActivateGameObject.Count; i++) {

            list_ThisWaveObject.Add(list_OfActivateGameObject[i]);
        }
    }


    public void EveryWaveSpawnOneObj(GameObject thisWave) {

       

        GameObject current = Instantiate(thisWave, transform.position, transform.rotation, transform_Store.transform);
        list_OfActivateGameObject.Add(current);
        current.SetActive(false);

        if (list_OfActivateGameObject.Count <= all_Postion.Length) {

            list_ActivateInHirachy.Add(current);

            for (int i = 0; i < all_Postion.Length; i++) {
                if (all_Postion[i].transform.childCount == 0) {
                    current.transform.SetParent(all_Postion[i]);
                    current.transform.localPosition = Vector3.zero;
                    current.gameObject.SetActive(true);

                    break;
                }
            }
            if (thisWave.TryGetComponent<Loan>(out Loan loan)) {
                CoinHandler.instance.SpawnCoinLoanTime(50, loan.transform.position);
            }

        }
        else {

            list_ThisWaveObject.Clear();

            for (int i = 0; i < list_OfActivateGameObject.Count; i++) {

                list_ThisWaveObject.Add(list_OfActivateGameObject[i]);
            }
            if (thisWave.TryGetComponent<Loan>(out Loan loan)) {
                CoinHandler.instance.SpawnCoinLoanTime(50, Vector3.zero);
            }

        }

      

    }

    public  void OneExtraETHAddCoin() {

        Debug.Log("One Extra ETHCoin Add");
        GameObject current = Instantiate(ethCoin, transform.position, transform.rotation, transform_Store.transform);
      
        list_OfActivateGameObject.Add(current);
        current.SetActive(false);
        if (list_OfActivateGameObject.Count <= all_Postion.Length) {

            list_ActivateInHirachy.Add(current);

        }

        for (int i = 0; i < all_Postion.Length; i++) {
            if (all_Postion[i].transform.childCount==0) {
                current.transform.SetParent(all_Postion[i]);
                current.transform.localPosition = Vector3.zero;
                current.gameObject.SetActive(true);
               all_Postion[i].GetComponent<RawMotion>().StopAnimation();
               
                break;
            }
        }
       
    }
    public void OneExtraBitCoinAddCoin() {

        Debug.Log("One Extra Bitcoin Add");
        GameObject current = Instantiate(bitcoin, transform.position, transform.rotation, transform_Store.transform);
       
        list_OfActivateGameObject.Add(current);
        if (list_OfActivateGameObject.Count <= all_Postion.Length) {
            list_ActivateInHirachy.Add(current);
        }
        current.SetActive(false);

        for (int i = 0; i < all_Postion.Length; i++) {
            if (all_Postion[i].transform.childCount == 0) {
                current.transform.SetParent(all_Postion[i]);
                current.transform.localPosition = Vector3.zero;
                current.gameObject.SetActive(true);
                all_Postion[i].GetComponent<RawMotion>().StopAnimation();
               
                break;
            }
        }

    }

    public void OnExtraFurAdd() {

        Debug.Log("One Extra Fur Add");
        GameObject current = Instantiate(fur, transform.position, transform.rotation, transform_Store.transform);

        list_OfActivateGameObject.Add(current);
        if (list_OfActivateGameObject.Count <= all_Postion.Length) {
            list_ActivateInHirachy.Add(current);
        }
        current.SetActive(false);

        for (int i = 0; i < all_Postion.Length; i++) {
            if (all_Postion[i].transform.childCount == 0) {
                current.transform.SetParent(all_Postion[i]);
                current.transform.localPosition = Vector3.zero;
                current.gameObject.SetActive(true);
                all_Postion[i].GetComponent<RawMotion>().StopAnimation();

                break;
            }
        }

    }

    public void RemoveGameObjectInList(GameObject Current) {

        if (list_ThisWaveObject != null) {
            list_ThisWaveObject.Remove(Current);
        }
        list_Symboldat.Remove(Current.GetComponent<SymbolData>());
        list_ActivateInHirachy.Remove(Current);
        list_OfActivateGameObject.Remove(Current);
        Destroy(Current);
    }




}
