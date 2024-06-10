using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class SceneController : MonoBehaviour
{
    public TextMeshProUGUI resources;

    void Awake(){
         
    }

    void Start(){
        if(GameData.runResources > 0){
            GameData.globalResources += GameData.runResources;
            GameData.runResources = 0;
        }
        updateResources();
    }
    
    public void NextScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PreviousScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
        PlayerPrefs.SetInt("globalResources", GameData.globalResources);
        PlayerPrefs.SetInt("suitUpgrade", GameData.upgradeLevels["suitUpgrade"]);
        PlayerPrefs.SetInt("sensorUpgrade", GameData.upgradeLevels["sensorUpgrade"]);
    }
    
    public void updateResources(){
        resources.text = "Resources: " + GameData.globalResources.ToString();
    }
}
