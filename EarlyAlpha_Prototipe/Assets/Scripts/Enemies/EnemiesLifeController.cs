using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EnemiesLifeController : MonoBehaviour{
    private GameObject levelController;
    public Image lifeBar;
    public float currentLife = 100;
    public float maxLife = 100;
   // public event Action<EnemiesLifeController> OnDisableEnemy;
    public bool isDesactivated = false;
    private Rigidbody rb; //En los atributos

    void Start(){
        levelController = GameObject.FindGameObjectWithTag("GameController");  
        rb = GetComponent<Rigidbody>(); 
    }

    public void GetDamage(float damage, Vector3 charPos, float pushingForce){
        //Apply force
        Vector3 knockbackDirection = rb.transform.position - charPos;
        knockbackDirection.y = 0;
        knockbackDirection.Normalize();
        rb.AddForce(knockbackDirection * pushingForce, ForceMode.Impulse);

        currentLife -= damage;
        lifeBar.fillAmount = currentLife / maxLife;
        if(currentLife <= 0){
            if(!isDesactivated){
                isDesactivated = true;
                levelController.GetComponent<LevelController>().SetProgress();
                GetComponent<CoinSpawner>().SpawnCoin();
                gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Bullet"){
            GetDamage(other.gameObject.GetComponent<ArrowController>().Damage,Vector3.zero, 0);
        }
    }
}
