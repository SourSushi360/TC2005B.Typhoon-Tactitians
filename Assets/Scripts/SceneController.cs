using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneController : MonoBehaviour
{
    public TextMeshProUGUI resources;
    public void NextScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PreviousScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

    void Start(){
        resources.text = "Resources: " + GameData.resources.ToString();
    }
    void Update(){
        //resources.text = "Resources: " + GameData.resources.ToString();
    }
}
