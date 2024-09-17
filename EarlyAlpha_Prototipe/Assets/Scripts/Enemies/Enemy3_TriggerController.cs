using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3_TriggerController : MonoBehaviour{
    private Collider childCollider;

    void Start(){
        childCollider = GetComponent<Collider>();
    }
    void OnTriggerEnter(Collider other) {
        if (other == childCollider) return;
        if(other.gameObject.tag == "Player"){
            GetComponent<Enemy3>().SetCurrentObjetive(other.gameObject);
        }
        else if(other.gameObject.tag == "Ally"){
            GetComponent<Enemy3>().SetCurrentObjetive(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other == childCollider) return;
        if(other.gameObject.tag == "Player" ||
           other.gameObject.tag == "Ally"){
            GetComponent<Enemy3>().SetCurrentCastle();
        }
    }

}
