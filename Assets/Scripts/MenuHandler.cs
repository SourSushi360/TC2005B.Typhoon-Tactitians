using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    void Start(){
        
        if(GameData.upgradeLevels.TryGetValue("suitUpgrade", out int value)){

        }else{
            GameData.upgradeLevels.Add("suitUpgrade", 0);
            GameData.upgradeLevels.Add("sensorUpgrade", 0);
        }
        
    }
    
    public void PlayGame(){
        GameData.globalResources = PlayerPrefs.GetInt("globalResources", 0);
        GameData.upgradeLevels["suitUpgrade"] = PlayerPrefs.GetInt("suitUpgrade", 0);
        GameData.upgradeLevels["sensorUpgrade"] = PlayerPrefs.GetInt("sensorUpgrade", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void NewGame(){
        GameData.globalResources = 0;
        GameData.upgradeLevels["suitUpgrade"] = 0;
        GameData.upgradeLevels["sensorUpgrade"] = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame(){
        PlayerPrefs.SetInt("globalResources", GameData.globalResources);
        PlayerPrefs.SetInt("suitUpgrade", GameData.upgradeLevels["suitUpgrade"]);
        PlayerPrefs.SetInt("sensorUpgrade", GameData.upgradeLevels["sensorUpgrade"]);
        Application.Quit();
        
    }
}
