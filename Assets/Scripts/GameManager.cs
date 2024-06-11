using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _collectedResources;

    [SerializeField]
    private UnityEvent _successfulExtraction;

    [SerializeField]
    private UnityEvent _failedExtraction;

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
        _successfulExtraction.Invoke();
        StartCoroutine(waitForReader());
    }

    public void PlayerDied(){
        _failedExtraction.Invoke();
        StartCoroutine(waitForReader());
        foodCount = 0;
        GameData.runResources = 0;
        _collectedResources.Invoke();
    }

    public IEnumerator waitForReader()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
}
