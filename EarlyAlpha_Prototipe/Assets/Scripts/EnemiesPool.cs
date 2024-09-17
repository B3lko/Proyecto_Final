using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesPool : MonoBehaviour{
    [SerializeField] private GameObject Enemy1;
    [SerializeField] private GameObject Enemy2;
    private int poolSize = 20;
    [SerializeField] private List<GameObject> enemyList;
    private static EnemiesPool instance;
    public static EnemiesPool Instance {get {return instance;} }

    private void Awake() {
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }

    void Start(){
        AddEnemiesToPool(poolSize);
        DisableAllEnemies();
    }

    public void DisableAllEnemies(){
        for(int i = 0; i < poolSize; i++){
            Debug.Log("fuck");
            enemyList[i].GetComponent<ObjectActiveScene>().desactivar();//SetActive(false);
        }
    }

    private void AddEnemiesToPool(int poolSize){
        for(int i = 0; i < poolSize; i++){
            int rand2 = Random.Range(1,3);
            GameObject Enemy = null;
            switch(rand2){
                case 1:Enemy = Instantiate(Enemy1);break;
                case 2:Enemy = Instantiate(Enemy2);break;
            }
            Enemy.SetActive(false);
            enemyList.Add(Enemy);
        }
    }

    public GameObject RequestEnemy(){
        for(int i = 0; i < enemyList.Count; i++){
            if(!enemyList[i].activeSelf){
                enemyList[i].SetActive(true);
                return enemyList[i];
            }
        }
        AddEnemiesToPool(1);
        enemyList[enemyList.Count - 1].SetActive(true);
        return enemyList[enemyList.Count - 1];
    }
}
