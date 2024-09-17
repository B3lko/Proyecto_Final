using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour{
    //Index Level
    public int indexLevel;

    [SerializeField] GameObject SpawnController;

    //Progress Bar
    [SerializeField] Image progressBar;
    private float EnemiesNumber;
    private float EnemiesKilled = 0;
    
    //UI
    public GameObject Lose;
    public GameObject Win;
    public GameObject btnMenu1;
    public GameObject btnRestart1;
    public GameObject btnMenu;
    public GameObject btnRestart;
    public GameObject btnNext;

    public int GetIndex(){
        return indexLevel;
    }

    void OnEnable() {
        Time.timeScale = 1;
        SpawnController.GetComponent<SpawnController>().SetCanSpawn(true);
    }

    void Start() {
        EnemiesNumber = SpawnController.GetComponent<SpawnController>().GetAmountEnemies(indexLevel);
    }
    
    void Update(){
        if(btnNext.GetComponent<pressbtn>().press){
            btnNext.GetComponent<pressbtn>().press = false;
            switch(indexLevel){
                case 1:SceneManager.LoadScene("Level_02");break;
                case 2:SceneManager.LoadScene("Level_03");break;
                case 3:SceneManager.LoadScene("Level_04");break;
                case 4:SceneManager.LoadScene("Level_05");break;
                case 5:SceneManager.LoadScene("Level_06");break;
                case 6:SceneManager.LoadScene("Level_07");break;
                case 7:SceneManager.LoadScene("Level_08");break;
                case 8:SceneManager.LoadScene("Level_09");break;
                case 9:SceneManager.LoadScene("Level_10");break;
                case 10:SceneManager.LoadScene("Level_11");break;
                case 11:SceneManager.LoadScene("Level_12");break;
                case 12:SceneManager.LoadScene("Level_13");break;
                case 13:SceneManager.LoadScene("Level_14");break;
                case 14:SceneManager.LoadScene("Level_15");break;
                case 15:SceneManager.LoadScene("Level_16");break;
                case 16:SceneManager.LoadScene("Level_17");break;
                case 17:SceneManager.LoadScene("Level_18");break;
                case 18:SceneManager.LoadScene("Level_19");break;
                case 19:SceneManager.LoadScene("Level_20");break;
            }
        }
        if(btnMenu.GetComponent<pressbtn>().press){
            btnMenu.GetComponent<pressbtn>().press = false;
            SceneManager.LoadScene("MainMenu");
        }
        if(btnMenu1.GetComponent<pressbtn>().press){
            btnMenu1.GetComponent<pressbtn>().press = false;
            SceneManager.LoadScene("MainMenu");
        }
        if(btnRestart.GetComponent<pressbtn>().press){
            btnRestart.GetComponent<pressbtn>().press = false;
            Restart();
        }
        if(btnRestart1.GetComponent<pressbtn>().press){
            btnRestart1.GetComponent<pressbtn>().press = false;
            Restart();
        }
    }

    private void Restart(){
        SpawnController.GetComponent<EnemiesPool>().DisableAllEnemies();
        switch(indexLevel){
            case 1:SceneManager.LoadScene("Level_01");break;
            case 2:SceneManager.LoadScene("Level_02");break;
            case 3:SceneManager.LoadScene("Level_03");break;
            case 4:SceneManager.LoadScene("Level_04");break;
            case 5:SceneManager.LoadScene("Level_05");break;
            case 6:SceneManager.LoadScene("Level_06");break;
            case 7:SceneManager.LoadScene("Level_07");break;
            case 8:SceneManager.LoadScene("Level_08");break;
            case 9:SceneManager.LoadScene("Level_09");break;
            case 10:SceneManager.LoadScene("Level_10");break;
            case 11:SceneManager.LoadScene("Level_11");break;
            case 12:SceneManager.LoadScene("Level_12");break;
            case 13:SceneManager.LoadScene("Level_13");break;
            case 14:SceneManager.LoadScene("Level_14");break;
            case 15:SceneManager.LoadScene("Level_15");break;
            case 16:SceneManager.LoadScene("Level_16");break;
            case 17:SceneManager.LoadScene("Level_17");break;
            case 18:SceneManager.LoadScene("Level_18");break;
            case 19:SceneManager.LoadScene("Level_19");break;
            case 20:SceneManager.LoadScene("Level_20");break;
        }
    }

    public void SetProgress(){
        EnemiesKilled += 1;
        progressBar.fillAmount = EnemiesKilled / EnemiesNumber;
        if(EnemiesKilled == EnemiesNumber){
            SetWin();
        }

    }

   // public void SetProgress(){
       // PlayerPrefs.SetInt("CastleLife", EnemiesNumber);
        //PlayerPrefs.SetInt("PlayerLife", EnemiesNumber);
        //PlayerPrefs.SetInt("Coins", EnemiesNumber);
    //}

    public void GetProgress(){
        Debug.Log("a");
    }

    public void SetLose(){
        Time.timeScale = 0;
        SpawnController.GetComponent<SpawnController>().SetCanSpawn(false);
        Lose.SetActive(true);   
    }
    public void SetWin(){
        Time.timeScale = 0;
        SpawnController.GetComponent<SpawnController>().SetCanSpawn(false);
        Win.SetActive(true);   
    }
}
