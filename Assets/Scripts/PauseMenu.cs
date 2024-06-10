using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(gameIsPaused){
                Resume();
            }else{
                Pause();
            }
        }
    }

    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void QuitToLab(){
        Time.timeScale = 1f;
        GameManager.Instance.PlayerDied();
    }

    public void QuitGame(){
        PlayerPrefs.SetInt("globalResources", GameData.globalResources);
        PlayerPrefs.SetInt("suitUpgrade", GameData.upgradeLevels["suitUpgrade"]);
        PlayerPrefs.SetInt("sensorUpgrade", GameData.upgradeLevels["sensorUpgrade"]);
        Application.Quit();
    }
}
