using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour{
    [SerializeField] GameObject Enemy1;
    [SerializeField] GameObject Enemy2;
    [SerializeField] GameObject LevelController;
    private bool canSpawn = true;
    private int[] AmountEnemies = {5, 10, 15, 20, 30, 40, 60, 80, 90, 100};

    private int indexLevel;

    private int numEnemies;
    private int numEnemiesSpawned = 0;
    int min = 2;
    int max = 5;
    public float interval = 5.0f; // Intervalo de tiempo en segundos
    private float nextActionTime = 0.0f;
    
    void Start(){
        indexLevel = LevelController.GetComponent<LevelController>().GetIndex();
        numEnemies = AmountEnemies[indexLevel - 1];
        interval = 5.0f;
        nextActionTime = 0.0f;
    }
    public int GetAmountEnemies(int level){
        return AmountEnemies[level - 1];
    }

    void Update(){
        //Debug.Log("c");
       // if(canSpawn){
            SpawnEnemy();
        //}
        //else{
        //    Debug.Log("b");
        //}
    }

    public void SetCanSpawn(bool can){
        canSpawn = can;
    }

    private void SpawnEnemy(){
        if(numEnemiesSpawned < numEnemies){
            if(Time.time >= nextActionTime){
                int interval = Random.Range(min, max);
                nextActionTime += interval;
                int rand2 = Random.Range(1,3);
                switch(rand2){
                    case 1:Instantiate(Enemy1, transform.position, transform.rotation);break;
                    case 2:Instantiate(Enemy2, transform.position, transform.rotation);break;
                }
                numEnemiesSpawned += 1;
            }
        }
    }

   /* private void SpawnEnemy(){
        if(numEnemiesSpawned < numEnemies){
            if(Time.time >= nextActionTime){
                nextActionTime += interval;
                Debug.Log("A");
                GameObject Enemy = EnemiesPool.Instance.RequestEnemy();
                Enemy.transform.position = transform.position;
                Enemy.transform.rotation = transform.rotation;
                numEnemiesSpawned += 1;
            }
        }
    }*/
}
