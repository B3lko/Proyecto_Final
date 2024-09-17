using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtackControllerPlayer : MonoBehaviour{
    [SerializeField] Image cooldownBar;
    private float damage = 10; //20 5;
    //private float interval = 0.5f;//2;
    private float pushingForce = 6f;//2.5f;//10;
    public float cooldownTime = 0.75f;
    private HashSet<Collider> enemiesInRange = new HashSet<Collider>();
    private Collider attackArea;
    private float cooldownTimer;
    private bool isOnCooldown = false;

    void Start(){
        attackArea = GetComponent<Collider>();
    }

    void Update(){
        enemiesInRange.RemoveWhere(enemy => enemy == null || !enemy.gameObject.activeSelf);
        Attack();
        CoolDown();
    }

    private void CoolDown(){
        if(isOnCooldown){
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0){
                isOnCooldown = false;
                cooldownBar.fillAmount = 1f;
            }
            else{
                cooldownBar.fillAmount = 1 - (cooldownTimer / cooldownTime);
            }
        }
    }

    /*void Attack(){
        if(Input.GetMouseButtonDown(0) && !isOnCooldown){
            isOnCooldown = true;
            StartCooldown();
            foreach (Collider enemy in enemiesInRange){
                if (enemy != null && enemy.CompareTag("Enemy")){
                    enemy.GetComponent<EnemiesLifeController>().GetDamage(damage, transform.position, pushingForce);
                }
            }
        }
    }*/
    void Attack(){
        if (Input.GetMouseButtonDown(0) && !isOnCooldown){
            isOnCooldown = true;
            StartCooldown();
            foreach (Collider enemy in enemiesInRange){
                if (enemy != null && enemy.CompareTag("Enemy")){
                    EnemiesLifeController lifeController = enemy.GetComponent<EnemiesLifeController>();
                    if (lifeController != null){
                        lifeController.GetDamage(damage, transform.position, pushingForce);
                    }
                }
            }
        }
    }

    void StartCooldown(){
        isOnCooldown = true;
        cooldownTimer = cooldownTime;
        cooldownBar.fillAmount = 0f;
    }

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Enemy")){
            enemiesInRange.Add(other);
        }
    }

    void OnTriggerExit(Collider other){
        if (other.CompareTag("Enemy")){
            enemiesInRange.Remove(other);
        }
    }
}
