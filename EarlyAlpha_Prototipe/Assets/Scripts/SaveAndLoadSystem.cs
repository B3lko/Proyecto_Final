using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoadSystem : MonoBehaviour{
    public static void SavePlayerData(PlayerData playerData, int level){
        string json = JsonUtility.ToJson(playerData);
        PlayerPrefs.SetString("PlayerData_Level_" + level, json);
    }
    public static PlayerData LoadPlayerData(int level){
        string key = "PlayerData_Level_" + level;
        if (PlayerPrefs.HasKey(key)){
            string json = PlayerPrefs.GetString(key);
            return JsonUtility.FromJson<PlayerData>(json);
        }
        else{
            return null; // No data found for this level
        }
    }
}
