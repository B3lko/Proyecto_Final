using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour{
    [SerializeField] GameObject coin;
    private float probability = 30f;


    public void SpawnCoin(){
        int chance = Random.Range(0, 100);
        if (chance < probability){
            Instantiate(coin, transform.position, transform.rotation);
        }
    }
}
