using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour{
    private float speed = 2;
    private bool isMoving = true;
    private GameObject castle;
    private GameObject player;
    private GameObject ally = null;
    private float interval = 5.0f;
    private float nextActionTime = 0.0f;
    private float Damage = 5;
    private float rotationSpeed = 300f;
    private GameObject CurrentObjetive;
   // private float a = 0;
   // private float currentAngle = 0f;
   // public float rayDistance = 5f;
    private Collider parentCollider;

    void Start(){
        parentCollider = GetComponent<Collider>();
        castle = GameObject.FindGameObjectWithTag("Castle"); 
        player = GameObject.FindGameObjectWithTag("Player");  
        CurrentObjetive = castle;
    }

    void Update(){
        if(isMoving){
            GoToObjetive();
        }
        else{
           Attack();
        }
        
    }

    private void GoToObjetive(){
        Vector3 direction = (CurrentObjetive.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    
     private void Attack(){
        if (Time.time >= nextActionTime){
            nextActionTime += interval;
            if(CurrentObjetive == castle){
                castle.GetComponent<CastleController>().SetDamange(Damage);
            }
            else if(CurrentObjetive == player){
                player.GetComponent<PlayerController>().GetDamage(Damage);
            }
            else if(CurrentObjetive == ally){
                player.GetComponent<PlayerController>().GetDamage(Damage);
            }

        }
    }

    public void SetCurrentObjetive(GameObject newObjetive){
        CurrentObjetive = newObjetive;
    }
    public void SetCurrentCastle(){
        CurrentObjetive = castle;
        isMoving = true;
    }

    void OnTriggerEnter(Collider other){
        if (other == parentCollider) return;
        if(other.gameObject.tag == "Castle" ||
           other.gameObject.tag == "Player" ||
           other.gameObject.tag == "Ally"){
            isMoving = false;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other == parentCollider) return;
        if(other.gameObject.tag == "Castle" ||
           other.gameObject.tag == "Player" ||
           other.gameObject.tag == "Ally"){
            isMoving = true;
        }
    }
}
