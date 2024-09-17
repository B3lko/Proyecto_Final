using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour{
    private GameObject player;
    public float interval = 2.0f;
    private float nextActionTime = 0.0f;
    private float Damage = 5;
    private float timeSinceLastAttack = 0.0f; // Tiempo transcurrido desde el último ataque
    private Rigidbody rb; //En los atributos


    

    
    private bool canAttack = false;
    private float speed = 2;
    public float rotationSpeed = 5f; // Velocidad de rotación

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");  
        rb = GetComponent<Rigidbody>(); //En Algun Start o OnEnable
    }

    void Update(){
            timeSinceLastAttack += Time.deltaTime;
        if(canAttack){
            /*if(Time.time >= nextActionTime){
                nextActionTime += interval;
                player.GetComponent<PlayerController>().GetDamage(Damage);
            }*/
            // Verifica si ha pasado suficiente tiempo para el próximo ataque
            if (timeSinceLastAttack >= interval){
            Debug.Log("enemigo 2 ataca");

                //castle.GetComponent<CastleController>().SetDamange(Damage);
                player.GetComponent<PlayerController>().GetDamage(Damage);
                timeSinceLastAttack = 0.0f;
            }
        }
        else{
            Vector3 direction = (player.transform.position - transform.position).normalized;
            // Rotar hacia el objetivo
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
            // Mover hacia adelante
            transform.position += transform.forward * speed * Time.deltaTime;
            //Vector3 direction = player.transform.position - transform.position;
            //direction.Normalize();
            //transform.position += direction * speed * Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            canAttack = true;
        }
    }
    void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player"){
            canAttack = false;
        }
    }
}
