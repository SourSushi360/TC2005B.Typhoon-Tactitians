using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _collectedResources;

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

        foodCount = GameData.runResources;
    }

    public void SumarPuntos(int puntos) {
        foodCount += puntos;
        GameData.runResources += puntos;
        _collectedResources.Invoke();
        Debug.Log(foodCount);
    }

    public void PreviousScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

    public void PlayerDied(){
        foodCount = 0;
        GameData.runResources = 0;
        _collectedResources.Invoke();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
}
