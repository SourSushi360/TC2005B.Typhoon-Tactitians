using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // Singleton functionality, there should only be one instance of this object
    public static GameManager Instance {
        get;
        private set;
    }

    private int foodCount;
    public int FoodCount { get { return foodCount; } }
    
    void Awake()
    {
        // Corrective singleton
        // We check if the instance exists
        if(Instance != null){
            Destroy(gameObject);
        } else {
            // If not, we pick the space
            Instance = this;
        }

        foodCount = GameData.resources;
    }

    public void SumarPuntos(int puntos) {
        foodCount += puntos;
        GameData.resources += puntos;
        Debug.Log(foodCount);
    }

    public void PreviousScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
}
