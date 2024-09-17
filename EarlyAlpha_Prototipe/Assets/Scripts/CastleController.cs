using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastleController : MonoBehaviour{
    [SerializeField] GameObject levelController;
    public Image lifeBar;
    public float currentLife;
    public float maxLife;

    void Start() {
        lifeBar.fillAmount = currentLife / maxLife;
    }

    public void SetDamange(float damange){
        currentLife -= damange;
        lifeBar.fillAmount = currentLife / maxLife;
        if(currentLife <= 0){
            //gameObject.SetActive(false);
            levelController.GetComponent<LevelController>().SetLose();
        }
    }

    public void SetHealing(float healing){
        currentLife += healing;
        if(currentLife > maxLife){
            currentLife = maxLife;
        }
        lifeBar.fillAmount = currentLife / maxLife;
    }
}
