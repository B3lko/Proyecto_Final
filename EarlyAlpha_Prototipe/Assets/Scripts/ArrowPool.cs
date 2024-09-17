using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPool : MonoBehaviour{
    [SerializeField] private GameObject arrowPrefab;
    private int poolSize = 20;
    [SerializeField] private List<GameObject> arrowList;
    private static ArrowPool instance;
    public static ArrowPool Instance {get {return instance;} }

    private void Awake() {
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }

    void Start(){
        AddArrowsToPool(poolSize);
    }

    private void AddArrowsToPool(int poolSize){
        for(int i = 0; i < poolSize; i++){
            GameObject arrow = Instantiate(arrowPrefab);
            arrow.SetActive(false);
            arrowList.Add(arrow);
        }
    }

    public GameObject RequestArrow(){
        for(int i = 0; i < arrowList.Count; i++){
            if(!arrowList[i].activeSelf){
                arrowList[i].SetActive(true);
                return arrowList[i];
            }
        }
        AddArrowsToPool(1);
        arrowList[arrowList.Count - 1].SetActive(true);
        return arrowList[arrowList.Count - 1];
    }

}
