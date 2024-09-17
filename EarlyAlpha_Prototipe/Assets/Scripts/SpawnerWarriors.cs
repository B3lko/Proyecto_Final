using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerWarriors : MonoBehaviour{
    private GameObject player;
    [SerializeField] GameObject btnArrow;
    [SerializeField] GameObject Archer;
    [SerializeField] GameObject btnHelmet;
    [SerializeField] GameObject Carpenter;
    private int archerPrice = 3;
    private int CarpenterPrice = 3;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player"); 
    }

    // Update is called once per frame
    void Update(){
        if(btnArrow.GetComponent<pressbtn>().press){
            btnArrow.GetComponent<pressbtn>().press = false;
            if(archerPrice <= player.GetComponent<PlayerController>().GetCoins()){
                Instantiate(Archer, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z - 2) + transform.forward * 2, transform.rotation);
                player.GetComponent<PlayerController>().SubtractCoins(archerPrice);
            }
        }
        if(btnHelmet.GetComponent<pressbtn>().press){
            btnHelmet.GetComponent<pressbtn>().press = false;
            if(CarpenterPrice <= player.GetComponent<PlayerController>().GetCoins()){
                Instantiate(Carpenter, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z - 2) + transform.forward * 2, transform.rotation);
                player.GetComponent<PlayerController>().SubtractCoins(CarpenterPrice);
            }
        }
    }
}
