using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private float speed = 5;
    public float Damage  = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("A");
        gameObject.SetActive(false);
    }

/*
vida_jugador
vida_castillo
Monedas
Niveles bloqueados/Desbloqueados
*/
    public void SaveData(){

    }





   
}
