using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherController : MonoBehaviour{
    private float detectionRange = 15f;
    public GameObject bulletPrefab;
    private float shootInterval = 1f;
    private float shootTimer;
    private bool isEnemySet = false;
    private bool isInPosition = false;
    private GameObject Enemy = null;
    private float speed = 3f;
    private float rotationSpeed = 5f;
    private float stoppingDistance = 0.1f;
    private Vector3 targetPosition = new Vector3(-3f, 0.5f, 7f);

    void Start() {
        float x = Random.Range(-10.0f, 13.0f);
        targetPosition = new Vector3(x, 0.5f, 7f);
    }

    void Update(){
        if(!isInPosition){
            Vector3 direction = (targetPosition - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
            transform.position += transform.forward * speed * Time.deltaTime;
            if (Vector3.Distance(transform.position, targetPosition) <= stoppingDistance){
                isInPosition = true;
            }
        }
        else{
            if(!isEnemySet){
                Detect();
            }
            else{
                if(Enemy.GetComponent<EnemiesLifeController>().isDesactivated){
                    isEnemySet = false;
                    Enemy = null;
                }
                if(Enemy != null){
                    Shoot();
                }
            }
        }
    }

    void Detect(){
        transform.Rotate(Vector3.up, 45 * Time.deltaTime);
        RaycastHit hit;
        Ray ray = new Ray(new Vector3(transform.position.x, transform.position.y + 1,transform.position.z), transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * detectionRange, Color.yellow);
        if (Physics.Raycast(ray, out hit, detectionRange)){
            if (hit.collider.CompareTag("Enemy")){
                isEnemySet = true;
                Enemy = hit.collider.gameObject;
            }
        }
    }

    void Shoot(){
        Vector3 direction = (Enemy.transform.position - transform.position).normalized;
        direction.y = 0; // Esto asegura que solo gire en el eje Y
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        //Quaternion lookRotation = Quaternion.LookRotation(Enemy.transform.position);
        //transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval){
            shootTimer = 0f;
            GameObject arrow = ArrowPool.Instance.RequestArrow();
            arrow.transform.position = (new Vector3(transform.position.x, transform.position.y + 1, transform.position.z) + transform.forward * 2);
            arrow.transform.rotation = transform.rotation;
            //GameObject bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z) + transform.forward * 2, transform.rotation);
            //bullet.transform.LookAt(Enemy.transform.position);
            arrow.transform.LookAt(Enemy.transform.position);
            //Rigidbody rb = bullet.GetComponent<Rigidbody>();
            Rigidbody rb = arrow.GetComponent<Rigidbody>();
            if (rb != null){
                //rb.velocity = bullet.transform.forward * 20f;
                rb.velocity = arrow.transform.forward * 20f;
            }
        }
    }
}
