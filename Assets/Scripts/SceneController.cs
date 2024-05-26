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
        if(GameData.upgradeLevels.TryGetValue("suitUpgrade", out int value)){

        }else{
            GameData.upgradeLevels.Add("suitUpgrade", 0);
            GameData.upgradeLevels.Add("sensorUpgrade", 0);
        }
    }
    void FixedUpdate(){
        resources.text = "Resources: " + GameData.resources.ToString();
        
    }
    
    public void NextScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PreviousScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
    
}
