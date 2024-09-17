using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBarController : MonoBehaviour{
    private GameObject cam;

    void Start() {
        cam = GameObject.FindGameObjectWithTag("MainCamera");  
    }

    void Update(){
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
    }
}