using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour{
    [SerializeField] private GameObject BtnPlay;
    [SerializeField] private GameObject BtnBack;
   /* [SerializeField] private GameObject BtnLevel1;
    [SerializeField] private GameObject BtnLevel2;
    [SerializeField] private GameObject BtnLevel3;
    [SerializeField] private GameObject BtnLevel4;*/
    [SerializeField] private GameObject BtnLevel5;
    [SerializeField] private GameObject BtnLevel6;

    [SerializeField] private GameObject WindowsLevel;
    [SerializeField] private GameObject WindowsMenu;

    void Update(){
       /* if(BtnLevel1.GetComponent<pressbtn>().press == true){
            BtnLevel1.GetComponent<pressbtn>().press = false;
            SceneManager.LoadScene("Level_01");
        }
        if(BtnLevel2.GetComponent<pressbtn>().press == true){
            BtnLevel2.GetComponent<pressbtn>().press = false;
            SceneManager.LoadScene("Level_02");
        }
        if(BtnLevel3.GetComponent<pressbtn>().press == true){
            BtnLevel3.GetComponent<pressbtn>().press = false;
            SceneManager.LoadScene("Level_03");
        }
        if(BtnLevel1.GetComponent<pressbtn>().press == true){
            BtnLevel1.GetComponent<pressbtn>().press = false;
            SceneManager.LoadScene("Level_04");
        }*/
        if(BtnLevel5.GetComponent<pressbtn>().press == true){
            BtnLevel5.GetComponent<pressbtn>().press = false;
            SceneManager.LoadScene("Level_05");
        }
        if(BtnLevel6.GetComponent<pressbtn>().press == true){
            BtnLevel6.GetComponent<pressbtn>().press = false;
            SceneManager.LoadScene("Level_06");
        }
        if(BtnBack.GetComponent<pressbtn>().press == true){
            BtnBack.GetComponent<pressbtn>().press = false;
            WindowsLevel.SetActive(false);
            WindowsMenu.SetActive(true);
        }
        if(BtnPlay.GetComponent<pressbtn>().press == true){
            BtnPlay.GetComponent<pressbtn>().press = false;
            WindowsLevel.SetActive(true);
            WindowsMenu.SetActive(false);
        }
    }
}
