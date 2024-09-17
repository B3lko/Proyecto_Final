using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpenterController : MonoBehaviour{
    private GameObject castle;
    Vector3 pos = new Vector3(-5f, 0.5f, -3.75f);
    private float speed = 1;
    private float rotationSpeed = 5f;
    private bool isMoving = true;

    private float interval = 7.5f;
    private float nextActionTime = 0.0f;
    private float timeSinceLastAttack = 0.0f; // Tiempo transcurrido desde el último ataque

    private float Healing = 5;

    void Start(){
        castle = GameObject.FindGameObjectWithTag("Castle"); 
    }

    // Update is called once per frame
    void Update(){
            timeSinceLastAttack += Time.deltaTime;
        if(isMoving){
            Vector3 direction = (castle.transform.position - transform.position).normalized;
            // Rotar hacia el objetivo
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
            // Mover hacia adelante
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else{
            /*if(Time.time >= nextActionTime){
                nextActionTime += interval;
                castle.GetComponent<CastleController>().SetHealing(Healing);
            }*/

            if (timeSinceLastAttack >= interval){
                castle.GetComponent<CastleController>().SetHealing(Healing);
                timeSinceLastAttack = 0.0f;
            }
        }

    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Castle"){
            isMoving = false;
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Castle"){
            isMoving = true;
        }
    }
}
