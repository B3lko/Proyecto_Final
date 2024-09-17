using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerController : MonoBehaviour{
    [SerializeField] GameObject levelController;
    [SerializeField] GameObject coinText;
    private int coinNumber = 10;
    public Image lifeBar;
    public float currentLife = 100;
    public float maxLife = 100;

    void Start() {
        coinText.GetComponent<TextMeshProUGUI>().text = "" + coinNumber;
    }

    public void GetDamage(float damage){
        currentLife -= damage;
        lifeBar.fillAmount = currentLife / maxLife;
        if(currentLife <= 0){
            gameObject.SetActive(false);
            levelController.GetComponent<LevelController>().SetLose();
        }
    }

    void Update(){
        RotateChar();
        Move();
    }

    private void RotateChar(){
        // Plane de referencia en el que se encuentra el personaje (por ejemplo, el plano XZ si es un juego en 3D).
        Plane playerPlane = new Plane(Vector3.up, transform.position);

        // Ray desde la cámara hacia el punto del mouse.
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Variable para almacenar la distancia desde el rayo hasta el plano.
        float hitdist = 0.0f;
        // Si el rayo intersecta el plano...
        if (playerPlane.Raycast(ray, out hitdist)){
            // Punto donde el rayo intersecta el plano.
            Vector3 targetPoint = ray.GetPoint(hitdist);
            // Dirección hacia la que el personaje debe mirar.
            Vector3 targetDirection = targetPoint - transform.position;
            // Rotación necesaria para que el personaje mire hacia esa dirección.
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            // Aplicar la rotación al personaje.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10.0f);
        }
    }

    void Move(){
        if(Input.GetKey(KeyCode.W)){
            transform.Translate(Vector3.forward * 5 * Time.deltaTime);
            if(transform.position.x > 24){
                transform.position = new Vector3(24f, transform.position.y, transform.position.z);
            }
        }
    }

    public void SubtractCoins(int Coins){
        coinNumber -= Coins;
        coinText.GetComponent<TextMeshProUGUI>().text = "" + coinNumber;
    }

    public int GetCoins(){
        return coinNumber;
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Coin"){
            coinNumber += 1;
            coinText.GetComponent<TextMeshProUGUI>().text = "" + coinNumber;
            other.gameObject.SetActive(false);
             //text.GetComponent<TextMeshProUGUI>().text = "Number of bounces: " + bounce_cont;
        }
    }
    

}
