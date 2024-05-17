using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int foodCount;
    public int FoodCount { get { return foodCount; } }
    
    public void SumarPuntos(int puntos) {
        foodCount += puntos;
        Debug.Log(foodCount);
    }
}
