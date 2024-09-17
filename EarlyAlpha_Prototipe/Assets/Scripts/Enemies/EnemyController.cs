using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour{
    private float speed = 2;
    private bool isMoving = true;
    private GameObject castle;
    private float interval = 5.0f; // Intervalo de tiempo en segundos
    private float nextActionTime = 0.0f;
    private float timeSinceLastAttack = 0.0f; // Tiempo transcurrido desde el último ataque
    private float Damage = 10;
    public float rotationSpeed = 5f;

    void Start() {
        castle = GameObject.FindGameObjectWithTag("Castle");  
    }

    void Update(){
        //transform.Translate(Vector3.forward * 5 * Time.deltaTime);
        if(isMoving){
            //transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            Vector3 direction = (castle.transform.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
            // Mover hacia adelante
            transform.position += transform.forward * speed * Time.deltaTime;
            //canAttack();
        }
        else{
            //if (Time.time >= nextActionTime){
             //   nextActionTime += interval;
               // castle.GetComponent<CastleController>().SetDamange(Damage);
            //}
            timeSinceLastAttack += Time.deltaTime;
            // Verifica si ha pasado suficiente tiempo para el próximo ataque
            if (timeSinceLastAttack >= interval){
                castle.GetComponent<CastleController>().SetDamange(Damage);
                timeSinceLastAttack = 0.0f;
            }
        }
    }

    /*void canAttack(){
        RaycastHit hitInfo;
        Ray ray = new Ray(transform.position, new Vector3(-90f,0,0));
        Debug.DrawRay(ray.origin, ray.direction * 1f);
        if(Physics.Raycast(ray, out hitInfo, 1)){
            if(hitInfo.transform.gameObject.tag == "Castle"){
                isMoving = false;
            }
        } 
    }*/

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
